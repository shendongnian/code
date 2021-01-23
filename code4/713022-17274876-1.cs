    PdfPCell cell1 = new PdfPCell();
    Paragraph p1 = new Paragraph("Text 1", Font);
    p1.Alignment = Element.ALIGN_RIGHT;
    Paragraph p2 = new Paragraph("Text 2", Font);
    p2.Alignment = Element.ALIGN_RIGHT;
    
    cell1.AddElement(p1);
    cell1.AddElement(p2);
