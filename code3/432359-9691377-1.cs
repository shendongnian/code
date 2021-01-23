    using (Document document = new Document()) {
      PdfWriter writer = PdfWriter.GetInstance(document, STREAM);
      document.Open();
      PdfPTable table = new PdfPTable(4);
      for (int i = 1; i < 20; ++i) {
        table.AddCell(i.ToString());
      }
      int[] wantedRows = {0, 2, 3};
      document.Add(new Paragraph(string.Format(
        "Simulated table height: {0}",
        TotalRowHeights(document, writer.DirectContent, table, wantedRows)
      )));
    // uncomment block below to verify correct height is being calculated
    /* 
      document.Add(new Paragraph("Add the PdfPTable"));
      document.Add(table);
      float totalHeight = 0f;
      foreach (int i in wantedRows) {
        totalHeight += table.GetRowHeight(i);
      }
      document.Add(new Paragraph(string.Format(
        "Height after adding table: {0}", totalHeight
      )));
    */
      document.Add(new Paragraph("Test paragraph"));
    }
