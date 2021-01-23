    private void Document_Printed(object sender, PrintPageEventArgs e) {
      float scale;
      SizeF pageSize = new SizeF(
        PrintPreview.Document.DefaultPageSettings.PaperSize.Width,
        PrintPreview.Document.DefaultPageSettings.PaperSize.Height
      );
      Margins m = PrintPreview.Document.DefaultPageSettings.Margins;
      float printableHeight = pageSize.Height - (m.Top + m.Bottom);
      float printableWidth = pageSize.Width - (m.Left + m.Right);
      if (printableWidth < printableHeight) {
        if (labelSize.Width < labelSize.Height) {
          float r1 = printableWidth / labelSize.Width;
          float r2 = printableHeight / labelSize.Height;
          scale = (r1 < r2) ? r1 : r2;
        } else {
          scale = printableWidth / labelSize.Width;
        }
      } else {
        if (labelSize.Width < labelSize.Height) {
          scale = (printableHeight) / labelSize.Height;
        } else {
          float r1 = printableWidth / labelSize.Width;
          float r2 = printableHeight / labelSize.Height;
          scale = (r1 < r2) ? r1 : r2;
        }
      }
      float lh = scale * labelSize.Height;
      float lw = scale * labelSize.Width;
      float ml = scale * m.Left;
      float mt = scale * m.Top;
      Graphics G = e.Graphics;
      G.SmoothingMode = smoothMode;
      G.TextRenderingHint = TextRenderingHint.AntiAlias;
      for (int i = 0; (i < LabelsHorizontal) && !e.Cancel; i++) {
        float dx = i * (lw + ml); // Horizontal shift * scale
        for (int j = 0; (j < LabelsVertical) && !e.Cancel; j++) {
          float dy = j * (lh + mt); // Vertical shift * scale
          #region ' Panels '
          foreach (Panel item in panels) {
            float h = scale * item.Size.Height;
            float w = scale * item.Size.Width;
            float x = (ml + dx) + scale * item.Location.X;
            float y = (mt + dy) + scale * item.Location.Y;
            using (SolidBrush b = new SolidBrush(item.BackColor)) {
              G.FillRectangle(b, x, y, w, h);
            }
            using (Pen p = new Pen(Brushes.Black)) {
              G.DrawRectangle(p, x, y, w, h);
            }
          }
          #endregion
          #region ' Logo '
          if (logo != null) {
            float h = scale * logo.Height;
            float w = scale * logo.Width;
            float x = (ml + dx) + scale * logoPt.X;
            float y = (mt + dy) + scale * logoPt.Y;
            G.DrawImage(logo, x, y, w, h);
          }
          #endregion
          #region ' Labels '
          foreach (Label item in labels) {
            float h = scale * item.Size.Height;
            float w = scale * item.Size.Width;
            float x = (ml + dx) + scale * item.Location.X;
            float y = (mt + dy) + scale * item.Location.Y;
            Color c = PrintPreview.Document.DefaultPageSettings.Color ? item.ForeColor : Color.Black;
            Font font = new Font(item.Font.FontFamily, scale * item.Font.Size, item.Font.Style);
            using (SolidBrush b = new SolidBrush(c)) {
              StringFormat format = GetStringFormatFromContentAllignment(item.TextAlign);
              format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;
              format.Trimming = StringTrimming.None;
              PointF locationF = new PointF(x, y);
              SizeF size = new SizeF(w, h);
              RectangleF r = new RectangleF(locationF, size);
              G.DrawString(item.Text, font, b, r, format);
            }
          }
          #endregion
          #region ' Barcodes '
          foreach (AcpBarcodeControl item in barcodes) {
            Image img = item.GetBarcodeImage(item.BarcodeText);
            if (img != null) {
              float h = scale * item.Size.Height;
              float w = scale * item.Size.Width;
              float x = (ml + dx) + scale * item.Location.X;
              float y = (mt + dy) + scale * item.Location.Y;
              G.DrawImage(img, x, y, w, h);
            }
          }
          #endregion
          labelsPrinted++;
        }
      }
    }
