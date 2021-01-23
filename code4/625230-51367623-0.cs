        private void textBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (textBox1.SelectedText.Length > 0)
            {
                txtTextSelected.Text = textBox1.SelectedText;
                Clipboard.SetText(textBox2.Text);//This is optional
            }
            else
            {
                textBox2.Text = "";
                Clipboard.Clear();//This is optional
            }
        }
