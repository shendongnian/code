    var stringArray = text.Split(@'\t');
    
    var paragraph = new Paragraph();
    
    for(var i = 0;i <= stringArray.Length();i++)
    {
        paragraph.Append(new Run(new Text(str)));
        if(i != stingArray.Length())
           paragraph.Append(new Run(new TabChar()));
    }
    
    m_wordprocessingDocument.MainDocumentPart.Document.Body.AppendChild(paragraph);
