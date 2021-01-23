    private void PaintCell(Graphics g, Rectangle cellBounds, string longWord) {
      g.TextRenderingHint = TextRenderingHint.AntiAlias;
      float wordLength = 0;
      StringBuilder sb = new StringBuilder();
      List<string> words = new List<string>();
      foreach (char c in longWord) {
        float charWidth = g.MeasureString(c.ToString(), SystemFonts.DefaultFont,
                                          Point.Empty, StringFormat.GenericTypographic).Width;
        if (sb.Length > 0 && wordLength + charWidth > cellBounds.Width) {
          words.Add(sb.ToString());
          sb = new StringBuilder();
          wordLength = 0;
        }
        wordLength += charWidth;
        sb.Append(c);
      }
      if (sb.Length > 0)
        words.Add(sb.ToString());
      g.TextRenderingHint = TextRenderingHint.SystemDefault;
      g.DrawString(string.Join(Environment.NewLine, words.ToArray()),
                   SystemFonts.DefaultFont,
                   Brushes.Black,
                   cellBounds,
                   StringFormat.GenericTypographic);
    }
