    public class RoundRectangle : IPdfPCellEvent {
      public void CellLayout(
        PdfPCell cell, Rectangle rect, PdfContentByte[] canvas
      ) 
      {
        PdfContentByte cb = canvas[PdfPTable.LINECANVAS];
        cb.RoundRectangle(
          rect.Left,
          rect.Bottom,
          rect.Width,
          rect.Height,
          4 // change to adjust how "round" corner is displayed
        );
        cb.SetLineWidth(1f);
        cb.SetCMYKColorStrokeF(0f, 0f, 0f, 1f);
        cb.Stroke();
      }
    }
