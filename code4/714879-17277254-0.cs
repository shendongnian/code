    /**
     * Inner class to add a table as header.
     */
    protected class TableHeader : PdfPageEventHelper {
      /** The template with the total number of pages. */
      PdfTemplate total;
      
      /** The header text. */
      public string Header { get; set; }
      /**
       * Creates the PdfTemplate that will hold the total number of pages.
       */
      public override void OnOpenDocument(PdfWriter writer, Document document) {
        total = writer.DirectContent.CreateTemplate(30, 16);
      }
      
      /**
       * Adds a header to every page
       */
      public override void OnEndPage(PdfWriter writer, Document document) {
        PdfPTable table = new PdfPTable(3);
        try {
          table.SetWidths(new int[]{24, 24, 2});
          table.TotalWidth = 527;
          table.LockedWidth = true;
          table.DefaultCell.FixedHeight = 20;
          table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
          table.AddCell(Header);
          table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
          table.AddCell(string.Format("Page {0} of", writer.PageNumber));
          PdfPCell cell = new PdfPCell(Image.GetInstance(total));
          cell.Border = Rectangle.BOTTOM_BORDER;
          table.AddCell(cell);
          table.WriteSelectedRows(0, -1, 34, 803, writer.DirectContent);
        }
        catch(DocumentException de) {
          // ...
          throw de;
        }
      }
      
      /**
       * Fills out the total number of pages before the document is closed.
       */
      public override void OnCloseDocument(PdfWriter writer, Document document) {
        ColumnText.ShowTextAligned(
          total, Element.ALIGN_LEFT,
    // NewPage() already called when closing the document; subtract 1
          new Phrase((writer.PageNumber - 1).ToString()),
          2, 2, 0
        );
      }
    }
