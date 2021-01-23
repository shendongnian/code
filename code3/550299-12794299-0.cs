    public static string GetStringFromRichTextBox(RichTextBox richTextBox)
    {
        TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        return textRange.Text;
    }
