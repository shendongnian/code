    int height = 150;
    int width = 250;
    byte []byteArray=null;
    
    using (Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
    {
        int fontSize = 12;
        string fontName = "Arial";
        System.Drawing.Font rectangleFont = new System.Drawing.Font(fontName, fontSize, FontStyle.Bold);
        Graphics g = Graphics.FromImage(bitmap);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Color backgroundColor = Color.White;
        g.Clear(backgroundColor);
        g.DrawString(fontName, rectangleFont, SystemBrushes.WindowText, new PointF(10, 40));
    
        using (MemoryStream outputStream = new MemoryStream())
        {
            bitmap.Save(outputStream, ImageFormat.Jpeg);
            byteArray = outputStream.ToArray();
        }
    }
