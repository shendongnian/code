    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);  
    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(@"D:\Syed\New PDF\PDF.pdf", FileMode.Create));// Output PDF File Path
    Response.Write("File Created Successfully");
    pdfDoc.Open();
    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, new StreamReader(@"D:\Syed\test.html"));//This is input HTML file path
    pdfDoc.Close();
