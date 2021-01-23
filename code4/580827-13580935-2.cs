    PdfPTable introTable = new PdfPTable(10);
    introTable.HorizontalAlignment = 0;
    introTable.TotalWidth = 500f;
    introTable.LockedWidth = true;
    float[] widths = new float[] { 20f, 60f, 60f, 30f, 50f, 80f, 50f, 50f, 50f, 50f };
    introTable.SetWidths(widths);
    introTable.AddCell(createCell("SER.\nNO.", 2));
    introTable.AddCell(createCell("TYPE OF SHIPPING", 1));
    introTable.AddCell(createCell("ORDER NO.", 1));
    introTable.AddCell(createCell("QTY.", 1));
    introTable.AddCell(createCell("DISCHARGE PPORT", 1));
    introTable.AddCell(createCell("DESCRIPTION OF GOODS", 2));
    introTable.AddCell(createCell("LINE DOC. RECL DATE", 1));
    introTable.AddCell(createCell("CLEARANCE DATE", 2));
    introTable.AddCell(createCell("CUSTOM PERMIT NO.", 2));
    introTable.AddCell(createCell("DISPATCH DATE", 2));
    introTable.AddCell(createCell("AWB/BL NO.", 1));
    introTable.AddCell(createCell("COMPLEX NAME", 1));
    introTable.AddCell(createCell("G. W. Kgs.", 1));
    introTable.AddCell(createCell("DESTINATION", 1));
    introTable.AddCell(createCell("OWNER DOC. RECL DATE", 1));
    ....
    private static PdfPCell createCell(string text, int rowspan)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text));
        cell.Rowspan = rowspan;
        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        return cell;
    }
