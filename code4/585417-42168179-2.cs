        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText())
                    richTextBox1.Paste(DataFormats.GetFormat(DataFormats.Text));
                e.Handled = true;
            }
        }
