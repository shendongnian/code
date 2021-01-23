    PdfPTable table = new PdfPTable(1);
    PdfPCell cell = new PdfPCell(new Phrase("test 1"));
    cell.UseVariableBorders = true;
    cell.BorderColorLeft = BaseColor.BLUE;
    cell.BorderColorRight = BaseColor.ORANGE;
    table.AddCell(cell);
    
    cell = new PdfPCell(new Phrase("test 2"));
    cell.BorderColorLeft = BaseColor.RED;
    cell.BorderColorRight = BaseColor.GREEN;
    cell.BorderColorTop = BaseColor.PINK;
    cell.BorderColorBottom = BaseColor.YELLOW;
    cell.BorderWidthLeft = 1f;
    cell.BorderWidthRight = 1f;
    cell.BorderWidthTop = 1f;
    cell.BorderWidthBottom = 1f;
    table.AddCell(cell);
    
    cell = new PdfPCell(new Phrase("test 3"));
    cell.BorderColor = BaseColor.GREEN;
    table.AddCell(cell);
