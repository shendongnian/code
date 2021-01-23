    private void panel1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
      string[] numbers = new string[] { "1", "2", ".", "3", "4", "5", "6", "8" };
      int x = 10;
      int y = 30;
      foreach (string num in numbers) {
        Font testFont;
        if (num == "4" || num == "5" || num == "6")
          testFont = new Font("Arial", 16, FontStyle.Bold);
        else
          testFont = new Font("Arial", 11, FontStyle.Regular);
        float offset = testFont.SizeInPoints / 
                       testFont.FontFamily.GetEmHeight(testFont.Style) * 
                       testFont.FontFamily.GetCellAscent(testFont.Style);
        float pixels = e.Graphics.DpiY / 72f * offset;
        int numTop = y - (int)(pixels + 0.5f);
        TextRenderer.DrawText(e.Graphics, num, testFont, new Point(x, numTop), 
                              Color.Black, Color.Empty, TextFormatFlags.NoPadding);
        x += TextRenderer.MeasureText(e.Graphics, num, testFont, 
                                      Size.Empty, TextFormatFlags.NoPadding).Width;
      }
      e.Graphics.DrawLine(Pens.Red, new Point(5, y + 1), new Point(x + 5, y + 1));
    }
