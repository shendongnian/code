    Document doc = new Document(dataDir + "Test.docx");
    
    // This sample introduces the RenderedDocument class and other related classes which provide an API wrapper for
    // the LayoutEnumerator. This allows you to access the layout entities of a document using a DOM style API.
    
    // Create a new RenderedDocument class from a Document object.
    RenderedDocument layoutDoc = new RenderedDocument(doc);
    
    // Loop through the layout info of each page
    foreach (RenderedPage page in layoutDoc.Pages)
    {
        if (page.Columns.Count > 1)
        {
            // Find the last line in the first column on the page.
            RenderedLine lastLine = page.Columns.First.Lines.Last;
    
            // This is the pargraph which belongs to the last line on the page, implement required logic and checks here.
            Paragraph para = lastLine.Paragraph;
            if (para.ParagraphFormat.StyleIdentifier == StyleIdentifier.Heading1)
            {
                // Insert a blank paragraph before the last paragraph in the column.
                para.ParentNode.InsertBefore(new Paragraph(doc), para);
            }
    
    
            // This is how to get the first line in the second column and the related paragraph.
            // Use this if it is required.
            RenderedLine secondColumnLine = page.Columns[1].Lines.First;
            Paragraph secondColumnPara = lastLine.Paragraph;
        }
    }
