using System;
using System.Windows.Forms;

namespace laboratory_ass_2
{
    public partial class Form1 : Form
    {
        // Custom delegate and event for task 3
        public delegate void CustomEventHandler(string message);
        public event CustomEventHandler OnCustomEvent;

        // Custom event for character limit (Bonus Task)
        public event CustomEventHandler OnCharacterLimitExceeded;

        public Form1()
        {
            InitializeComponent();

            // Subscribe to custom events
            OnCustomEvent += HandleCustomEvent;
            OnCharacterLimitExceeded += HandleCharacterLimitExceeded;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Task 2: Button1 Click Event
            label1.Text = "Button1 clicked";

            // Task 3: Raise custom event
            RaiseCustomEvent("Custom event triggered by Button1");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Task 2: Button2 Click Event - Clears textBox1 and label1
            textBox1.Text = "";
            label1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Task 2: Display updated text in label1
            label1.Text = "You typed: " + textBox1.Text;

            // Bonus Task: Check if character limit exceeded
            if (textBox1.Text.Length > 10)
            {
                OnCharacterLimitExceeded?.Invoke("Character limit exceeded (more than 10 characters).");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Task 2: Display message when Enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                label1.Text = "Enter key pressed";
                e.Handled = true; // Prevents the 'ding' sound
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Task 2: Update label1 based on checkbox state
            if (checkBox1.Checked)
            {
                label1.Text += "\nCheckbox is checked!";
            }
            else
            {
                label1.Text += "\nCheckbox is unchecked.";
            }
        }

        // Method to raise custom event for Task 3
        private void RaiseCustomEvent(string message)
        {
            OnCustomEvent?.Invoke(message);
        }

        // Custom event handler for Task 3
        private void HandleCustomEvent(string message)
        {
            label1.Text = message;
        }

        // Custom event handler for Bonus Task
        private void HandleCharacterLimitExceeded(string message)
        {
            label1.Text = message;
        }
    }
}
