    string rtfText= ... //string from db
    byte[] byteArray = Encoding.ASCII.GetBytes(rtfText);
    using (MemoryStream ms = new MemoryStream(byteArray))
    {
        TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        tr.Load(ms, DataFormats.Rtf);
    }
