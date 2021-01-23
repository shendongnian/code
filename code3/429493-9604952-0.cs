    public static Bitmap Repaint(Bitmap source, Color backgroundColor)
    {
     Bitmap result = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
     using (Graphics g = Graphics.FromImage(result))
     {
      g.Clear(backgroundColor);
      g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height));
     }
    
     return result;
    }
