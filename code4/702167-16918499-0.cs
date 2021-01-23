        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false)
            {
                count++;
            }
            if (count == 1)
            {
                textBox1.Text = ("");
                count = 0;
                e.Handled = true; // this bit fixes it
            }
        }
