    string rtfText; //string to save to db
    TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
    using (MemoryStream ms = new MemoryStream())
    {
        tr.Save(ms, DataFormats.Rtf);
        rtfText = Encoding.ASCII.GetString(ms.ToArray());
    }
