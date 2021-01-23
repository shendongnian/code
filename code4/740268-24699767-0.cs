    PdfPTable table = new PdfPTable(4);
    table.TotalWidth = 400f;
    table.LockedWidth = true;
    PdfPCell header = new PdfPCell(new Phrase("Header"));
    header.Colspan = 4;
    table.AddCell(header);
    table.AddCell("Cell 1");
    table.AddCell("Cell 2");
    table.AddCell("Cell 3");
    table.AddCell("Cell 4");
    PdfPTable nested = new PdfPTable(1);
    nested.AddCell("Nested Row 1");
    nested.AddCell("Nested Row 2");
    nested.AddCell("Nested Row 3");
    PdfPCell nesthousing = new PdfPCell(nested);
    nesthousing.Padding = 0f;
    table.AddCell(nesthousing);
    PdfPCell bottom = new PdfPCell(new Phrase("bottom"));
    bottom.Colspan = 3;
    table.AddCell(bottom);
    doc.Add(table);
 
------------
 
    PdfPTable table = new PdfPTable(3);
    table.TotalWidth = 144f;
    table.LockedWidth = true;
    table.HorizontalAlignment = 0;
    PdfPCell left = new PdfPCell(new Paragraph("Rotated"));
    left.Rotation = 90;
    table.AddCell(left);
    PdfPCell middle = new PdfPCell(new Paragraph("Rotated"));
    middle.Rotation = -90;
    table.AddCell(middle);
    table.AddCell("Not Rotated");
    doc.Add(table);
