    try
    {
        iTextSharp.text.Document doc = new iTextSharp.text.Document();
        PdfWriter.GetInstance(doc, new FileStream("HelloWorld.pdf", FileMode.Create));
        doc.Open();
        doc.Add(new Paragraph("Hello World!"));
        doc.NewPage();
        doc.Add(new Paragraph("Hello World on a new page!"));
    }
    catch (Exception ex)
    {
    }
    finally 
    {
        doc.Close();
    }
