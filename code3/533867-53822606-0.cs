    using DocumentFormat.OpenXml.Packaging;
    
    private int CountWordPage(string filePath)
    {
        using (var wordDocument = WordprocessingDocument.Open(filePath, false))
        {
            return int.Parse(wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text);
        }
    }
