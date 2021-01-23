    using (Bitmap btm = new Bitmap(25, 30))
    {
       using (Graphics grf = Graphics.FromImage(btm))
       {
          using (Brush brsh = new SolidBrush(ColorTranslator.FromHtml("#ff00ffff")))
          {
             grf.FillEllipse(brsh, 0, 0, 19, 19);
          }
       }
    }
