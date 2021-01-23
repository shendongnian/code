    public static float TotalRowHeights(
      Document document, PdfContentByte content, 
      PdfPTable table, params int[] wantedRows) 
    {
      float height = 0f;
      ColumnText ct = new ColumnText(content);
    // respect current Document.PageSize    
      ct.SetSimpleColumn(
        document.Left, document.Bottom, 
        document.Right, document.Top
      );
      ct.AddElement(table);
    // **simulate** adding the PdfPTable to calculate total height
      ct.Go(true);
      foreach (int i in wantedRows) {
        height += table.GetRowHeight(i);
      }
      return height;
    }
