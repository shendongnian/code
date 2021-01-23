    public partial class Form2 : Form
    {
        [...]
        // This class member will store the string value 
        // the user enters in the text-box
        public String textFromTextBox = null;
        [...]
        // This is the event-handling code that you must place for
        // the OK button.
        private void button1_Click(object sender, EventArgs e)
        {
            this.textFromTextBox = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
