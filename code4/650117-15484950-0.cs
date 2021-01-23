    using (WordprocessingDocument doc =
       WordprocessingDocument.Open(@"test.docx", true))
    {
      Paragraph p = doc.MainDocumentPart.Document.Body.ChildElements.First<Paragraph>();
      if(p == null)
      {
        Console.Out.WriteLine("Paragraph not found.");
        return;
      }
      ParagraphProperties pp = p.ChildElements.First<ParagraphProperties>();
      if (pp == null)
      {
        pp = new ParagraphProperties();
        p.InsertBefore(pp, p.First());
      }
        
      BiDi bidi = new BiDi();
      pp.Append(bidi);
      
    }
