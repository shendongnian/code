    public partial class NumTextBox : TextBox
    {
        public NumTextBox()
        {
            LostFocus += new EventHandler(NumTextBox_LostFocus);
        }
        private void NumTextBox_LostFocus(object sender, EventArgs e)
        {
            this.Text = "OK";
        }
    }
