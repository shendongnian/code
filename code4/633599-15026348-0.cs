    string pdfpath = Server.MapPath("PDFs");
      Document doc = new Document();
      try
      {
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Graphics.pdf", FileMode.Create));
        doc.Open();
        PdfContentByte cb = writer.DirectContent;
        ...
   
