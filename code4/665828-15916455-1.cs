        private void Paste()
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                richTextBox1.Rtf = Clipboard.GetText(TextDataFormat.Rtf);
            }
        }
