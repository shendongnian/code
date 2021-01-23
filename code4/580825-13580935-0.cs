    PdfPTable table = new PdfPTable(2);
    table.TotalWidth = 216f;
    table.LockedWidth = true;
 
    // set width relatively
    float[] widths = new float[] { 1f, 2f };
    // or you can also use this
    // float[] widths = new float[] { 100f, 116f };
    table.SetWidths(widths);
    table.AddCell("Col 1");
    table.AddCell("Col 2");
