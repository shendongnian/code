    public byte[] PdfGeneratorAndPostProcessor()
    {
      byte[] newPdf;
    
      using (var pdf = new MemoryStream())
      using (var doc = new Document(iTextSharp.text.PageSize.A4))
      using (PdfWriter.GetInstance(doc, pdf))
      {
        doc.Open();
    
        // do stuff to the newly created doc...
        
        doc.Close();
        newPdf = pdf.GetBuffer();
      }      
    
      byte[] postProcessedPdf;
      var reader = new PdfReader(newPdf);
    
      using (var pdf = new MemoryStream())
      using (var stamper = new PdfStamper(reader, pdf))
      {
        var pageCount = reader.NumberOfPages;
        for (var i = 1; i <= pageCount; i++)
        {
          // do something on each page of the existing pdf
        }
    
        stamper.Close();
        postProcessedPdf = pdf.GetBuffer();
      }
    
      reader.Close();
      return postProcessedPdf;
    }
