    //-----------------------------------------------------------------------------------------------------------------
    // MeasureLeading Function
    // Measures the amount of white space above a line of text, in pixels. This is accomplished by drawing the text
    // onto an offscreen bitmap and then looking at each row of pixels until a non-white pixel is found.
    // The y coordinate of that pixel is the result. This represents the offset by which a line of text needs to be
    // raised vertically in order to make it top-justified.
    //-----------------------------------------------------------------------------------------------------------------
    public static int MeasureLeading(string Text, Font Font) {
      Size sz = MeasureText(Text, Font);
      Bitmap offscreen = new Bitmap(sz.Width, sz.Height);
      Graphics ofg = Graphics.FromImage(offscreen);
      ofg.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 100, 100));
      ofg.DrawString(Text, Font, new SolidBrush(Color.Black), 0, 0, StringFormat.GenericTypographic);
      for (int iy=0; iy<sz.Height; iy++) {
        for (int ix=0; ix<sz.Width; ix++) {
          Color c = offscreen.GetPixel(ix, iy);
          if ((c.R!=255) || (c.G!=255) || (c.B!=255)) return iy;
        }
      }
      return 0;
    }
    //-----------------------------------------------------------------------------------------------------------------
    // MeasureText Method
    // TextRenderer.MeasureText always adds about 1/2 em width of white space on the right,
    // even when NoPadding is specified. But it returns zero for an empty string.
    // To get the true string width, we measure the width of a string containing a single period
    // and subtract that from the width of our original string plus a period.
    //-----------------------------------------------------------------------------------------------------------------
    public static System.Drawing.Size MeasureText(string Text, System.Drawing.Font Font) {
      System.Windows.Forms.TextFormatFlags flags
        = System.Windows.Forms.TextFormatFlags.Left
        | System.Windows.Forms.TextFormatFlags.Top
        | System.Windows.Forms.TextFormatFlags.NoPadding
        | System.Windows.Forms.TextFormatFlags.NoPrefix;
      System.Drawing.Size szProposed = new System.Drawing.Size(int.MaxValue, int.MaxValue);
      System.Drawing.Size sz1 = System.Windows.Forms.TextRenderer.MeasureText(".", Font, szProposed, flags);
      System.Drawing.Size sz2 = System.Windows.Forms.TextRenderer.MeasureText(Text + ".", Font, szProposed, flags);
      return new System.Drawing.Size(sz2.Width - sz1.Width, sz2.Height);
    }
