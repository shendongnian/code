    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.GetData("Text") != null)
                    Clipboard.SetText((string)Clipboard.GetData("Text"), TextDataFormat.Text);
                else
                    e.Handled = true;
            }            
        }
