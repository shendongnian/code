    private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                MessageBox.Show("Please fill the field");
                e.Cancel = true;
            }
        }
