    PdfPTable table = new PdfPTable(10);
    table.HorizontalAlignment = 0;
    table.TotalWidth = 500f;
    table.LockedWidth = true;
    float[] widths = new float[] { 20f, 60f, 60f, 30f, 50f, 80f, 50f, 50f, 50f, 50f };
    table.SetWidths(widths);
    addCell(table, "SER.\nNO.", 2);
    addCell(table, "TYPE OF SHIPPING", 1);
    addCell(table, "ORDER NO.", 1);
    addCell(table, "QTY.", 1);
    addCell(table, "DISCHARGE PPORT", 1);
    addCell(table, "DESCRIPTION OF GOODS", 2);
    addCell(table, "LINE DOC. RECL DATE", 1);
    addCell(table, "CLEARANCE DATE", 2);
    addCell(table, "CUSTOM PERMIT NO.", 2);
    addCell(table, "DISPATCH DATE", 2);
    addCell(table, "AWB/BL NO.", 1);
    addCell(table, "COMPLEX NAME", 1);
    addCell(table, "G. W. Kgs.", 1);
    addCell(table, "DESTINATION", 1);
    addCell(table, "OWNER DOC. RECL DATE", 1);
    ....
    private static void addCell(PdfPTable table, string text, int rowspan)
    {
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        PdfPCell cell = new PdfPCell(new Phrase(text, times));
        cell.Rowspan = rowspan;
        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        table.AddCell(cell);
    }
