    private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                MessageBox.Show("Enter Was Pressed");
                textBox1.Text = new String(textBox1.Text.Where((ch, i) => i < textBox1.Text.Length - 2).ToArray());
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
