    public static class FlowDocumentScrollViewerEx
    {
        static public bool ReadFromFile(this FlowDocumentScrollViewer fDoc, String rtfFilePath)
        {
            RichTextBox retext = new RichTextBox();     // Just an intermediate class to perform conversion
            retext.Document = new FlowDocument();
            fDoc.Document = new FlowDocument();
            TextRange tr = new TextRange(retext.Document.ContentStart, retext.Document.ContentEnd);
            if (!File.Exists(rtfFilePath))
                return false;
            using (var fs = new FileStream(rtfFilePath, FileMode.OpenOrCreate))
            {
                tr.Load(fs, DataFormats.Rtf);
                fs.Close();
            }
            MemoryStream ms = new MemoryStream();
            System.Windows.Markup.XamlWriter.Save(retext, ms);
            tr.Save(ms, DataFormats.XamlPackage);
            TextRange flowDocRange = new TextRange(fDoc.Document.ContentStart, fDoc.Document.ContentEnd);
            flowDocRange.Load(ms, DataFormats.XamlPackage);
            return true;
        } //ReadFromFile
    } //class FlowDocumentScrollViewerEx
