        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageDown:
                case Keys.PageUp:
                    textBox2.Text = textBox1.Text;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }
