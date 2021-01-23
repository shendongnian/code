    ![PdfPTable table = new PdfPTable(1) {
      TotalWidth = 100, LockedWidth = true, 
      HorizontalAlignment = Element.ALIGN_LEFT
    };
    PdfPCell cell = new PdfPCell();
    Phrase p = new Phrase(new Chunk(image, 0, 0));
    p.Add(new Phrase("Print"));
    cell.AddElement(p);
    table.AddCell(cell);
    
    cell = new PdfPCell();
    p = new Phrase(new Chunk(image, 0, 0));
    p.Add(new Phrase("A long phrase that will make the PdfPCell wrap it's containing text."));
    cell.AddElement(p);
    table.AddCell(cell);
    document.Add(table);]
