    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(1); //<-- Main table
    table.TotalWidth = 540f;
    table.LockedWidth = true;
    float[] widths = new float[] { 540f };
    table.SetWidths(widths);
    table.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
    table.SpacingAfter = 10;
    PdfPTable bodyTable = new PdfPTable(1); //<--Nested Table
    bodyTable.TotalWidth = 540f;
    bodyTable.LockedWidth = true;
    float[] bodyWidths = new float[] { 540f };
    bodyTable.SetWidths(bodyWidths);
    bodyTable.HorizontalAlignment = 0;
    bodyTable.SpacingAfter = 10;
    bodyTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
    
    var para1 = new Paragraph("This is a long paragraph", blackNormal);
    para1.SetLeading(3f, 1f);
    PdfPCell bodyCell1 = new PdfPCell();
    bodyCell1.AddElement(para1);
    bodyCell1.Border = 0;
    bodyTable.AddCell(bodyCell1);
    
    iTextSharp.text.pdf.PdfPCell cellBody = new iTextSharp.text.pdf.PdfPCell(bodyTable);
    cellBody.BorderWidth = 0; //<--- This is what sets the border for the nested table
    table.AddCell(cellBody);
