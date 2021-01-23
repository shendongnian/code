    RoundRectangle rr = new RoundRectangle();    
    using (Document document = new Document()) {
      PdfWriter writer = PdfWriter.GetInstance(document, STREAM);
      document.Open();
      PdfPTable table = new PdfPTable(1);
      PdfPCell cell = new PdfPCell() {
        CellEvent = rr, Border = PdfPCell.NO_BORDER,
        Padding = 4, Phrase = new Phrase("test")
      };
      table.AddCell(cell);  
      document.Add(table);
    }
