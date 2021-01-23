        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox box = (RichTextBox)sender;
            box.Text = box.Text.Replace(Environment.NewLine, string.Empty);
            box.Text = box.Text.Replace("\n", string.Empty);
            box.SelectionStart = box.TextLength;
            box.ScrollToCaret();
        }
