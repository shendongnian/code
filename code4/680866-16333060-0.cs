    Bitmap yourImage = ...;
    Bitmap yourWatermark = ...;
    
    int newWaterWidth = (int)((float)yourImage.Width * .3);
    int newWaterHeight = (int)((float)yourImage.Height* .3);
    
    
    using(Bitmap resizedWaterm = new Bitmap(destWidth, destHeight))
    using(Graphics g = Graphics.FromImage((Image)resizedWaterm))
    {
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      g.DrawImage(yourWatermark, 0, 0, newWaterWidth , newWaterHeight );
    }
    
    int x = ..., y = ...;
    using(Graphics g2 = Graphics.FromImage((Image)resizedWaterm))
    {
      g2.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
    }
