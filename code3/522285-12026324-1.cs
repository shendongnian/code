    string pdfpath = Server.MapPath("PDFs");
    RoundRectangle rr = new RoundRectangle();
           
    using (Document document = new Document())
    {
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfpath + "/Graphics200.pdf", FileMode.CreateNew));
        document.Open();
        PdfPTable table = new PdfPTable(1);
        table.TotalWidth = 144f;
    
        table.LockedWidth = true;
        PdfPCell cell = new PdfPCell()
        {
            CellEvent = rr,
            Border = PdfPCell.NO_BORDER,
            Phrase = new Phrase("test")
        };
        table.AddCell(cell);
        document.Add(table);
    }
