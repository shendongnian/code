    using (MemoryStream ms = new MemoryStream())
    {
       Document document = new Document(PageSize.A4, 25, 25, 30, 30);
       PdfWriter writer = PdfWriter.GetInstance(document, ms);
       document.Open();
       document.Add(new Paragraph("Hello World"));
       document.Close();
       writer.Close();
       Response.ContentType = "pdf/application";
       Response.AddHeader("content-disposition", 
       "attachment;filename=First PDF document.pdf");
       Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
    }
