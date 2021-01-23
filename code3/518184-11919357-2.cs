      public void HighlightLastLine(RichTextBox TextControl, string TextToHighlight, Color HighlightColor, bool ClearColors = true)
        {
            TextControl.Text = TextControl.Text.Trim();
            if (ClearColors)
            {
                TextControl.SelectionStart = 0;
                TextControl.SelectionLength = 0;
                TextControl.SelectionColor = Color.Black;
            }
            int LastLineStartIndex = richTextBox1.Text.LastIndexOf(TextToHighlight);
            if (LastLineStartIndex >= 0)
            {
                TextControl.SelectionStart = LastLineStartIndex;
                TextControl.SelectionLength = TextControl.Text.Length - 1;
                TextControl.SelectionColor = HighlightColor;
                TextControl.SelectionStart = 0;
                TextControl.SelectionLength = 0;
            }
        }
