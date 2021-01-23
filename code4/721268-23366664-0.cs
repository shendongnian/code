        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length + 1;
        }
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Back)
            {
                String a = maskedTextBox1.Text + e.KeyChar;
                maskedTextBox1.Text = a.Substring(1, a.Length - 1);
                maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length + 1;
            }
        }
        
        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                maskedTextBox1.Text = "_" + maskedTextBox1.Text;
                maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length + 1;
            } 
        }
