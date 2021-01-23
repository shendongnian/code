    XNamespace W = @"http://schemas.openxmlformats.org/wordprocessingml/2006/main";
    using (
        WordprocessingDocument document =
            WordprocessingDocument.Open(@"YourDocPath\tabs_in_text.docx", true))
    {
        var body = document.MainDocumentPart.Document.GetFirstChild<Body>();
        var paras = body.Elements<Paragraph>();
    
        foreach (var para in paras)
        {
            //Ver. 1
            //var xml = XElement.Parse(para.OuterXml);
            // var count = xml.Descendants(W + "tab").Count();
            //Ver. 2
            var tabElements = para.Descendants<TabChar>();
            var count = tabElements.Count(); // Collect the counts into array or dictionary for your usage.
        }
    }
