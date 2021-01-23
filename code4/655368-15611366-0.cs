    using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter.GetInstance(document, ms);  // added
                document.Open();
                Response.Clear();
    
                Response.ContentType = "application/pdf";  // changed
                Response.AddHeader("content-disposition", "attachment;filename=PDFdocument1.pdf");
    
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            }
