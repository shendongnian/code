    void YourDrawMethod(Graphics g)
    {
      var wrongBrush = new SolidBrush(Color.Red);
      var correctBrush = new SolidBrush(Color.Green);
    
      var ff = new FontFamily("Arial");
      using(var font = new System.Drawing.Font(ff, 20))
      {
        int x = 0;
        int y = 0;    
    
        foreach(car letter in InputWord)
        {
          SolidBrush brush = InputWord[i] == CorrectWord[b] ? correctBrush : wrongBrush;
          g.DrawString(letter.ToString(), font, brush, new PointF(x, y));         
          Size sizeOfLetter = g.MeasureString(letter.ToString(), font);
          x += sizeOfLetter.Width;
        }
      }    
    
      wrongBrush.Dispose();
      correctBrush.Dispose();
    }    
