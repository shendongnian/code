        private void textBox1_KeyUp(object sender, EventArgs e)
        {
            GetWordFromCaretPosition(textBox1.Text, textBox1.SelectionStart);
        }
        private void textBox1_MouseUp(object sender, EventArgs e)
        {
            GetWordFromCaretPosition(textBox1.Text, textBox1.SelectionStart);
        }
        private string GetWordFromCaretPosition(string input, int position)
        {
            string word = string.Empty;
            //Yet to be implemented.
            return word;
        }
