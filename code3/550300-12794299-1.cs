    public static string GetRtfStringFromRichTextBox(RichTextBox richTextBox)
    {
        TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        MemoryStream ms = new MemoryStream();
        textRange.Save(ms, DataFormats.Rtf);
        return Encoding.Default.GetString(ms.ToArray());
    }
