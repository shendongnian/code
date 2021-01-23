    public void LayerImage(System.Drawing.Image Current, int LayerOpacity)
    {
        Bitmap bitmap = new Bitmap(Current);        
        int h = bitmap.Height;
        int w = bitmap.Width;
        Bitmap backg = new Bitmap(w, h + 20);
        Graphics g = null;
        try
        {
            g = Graphics.FromImage(backg);
            g.Clear(Color.White);
            Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            RectangleF rectf = new RectangleF(70, 90, 90, 50);
            Color color = Color.FromArgb(255, 128, 128, 128);
            Point atpoint = new Point(backg.Width / 2, backg.Height - 10);
            SolidBrush brush = new SolidBrush(color);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("BRAND AMBASSADOR", font, brush, atpoint, sf);
            g.Dispose();
            MemoryStream m = new MemoryStream();
            backg.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch { }
        Color pixel = new Color();
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                pixel = bitmap.GetPixel(x, y);
                backg.SetPixel(x, y, Color.FromArgb(LayerOpacity, pixel));
            }
        }
        MemoryStream m1 = new MemoryStream();
        backg.Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
        m1.WriteTo(Response.OutputStream);
        m1.Dispose();
        base.Dispose();
    }
