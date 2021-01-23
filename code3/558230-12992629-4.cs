    public void PaintTextJustification(Graphics g, string text, Font font, PointF location, int lineWidth, bool applyToLastLine)
    {
      string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      
      int wordCount = 0;
      float locY = location.Y;
      
      while (wordCount < words.Length)
      {
        StringBuilder rawLine = new StringBuilder();
        List<string> lineParts = new List<string>();
        
        while ((wordCount < words.Length) && (g.MeasureString(rawLine.ToString() + words[wordCount], font).Width < (float)lineWidth))
        {
          rawLine.Append(words[wordCount] + " ");
          lineParts.Add(words[wordCount] + " ");
          wordCount++;
        }
        string rawLineStr = rawLine.ToString().Trim();
        
        float padding = 0;
        if ((wordCount < words.Length) || (applyToLastLine))
        {
          // Only apply padding if not the last line.
          padding = ((float)lineWidth - g.MeasureString(rawLineStr, font).Width) / (lineParts.Count - 1);
        }
        
        float locX = location.X;
        foreach (string word in lineParts)
        {
          g.DrawString(word, font, Brushes.Black, new PointF(locX, locY));
          locX += g.MeasureString(word, font).Width + padding;
        }
        
        locY += g.MeasureString(rawLineStr, font).Height;
      }
    }
