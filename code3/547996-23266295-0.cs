    public void AddWatermark(string watermarkText, string image, string TColor) 
    {       
        System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(Proot + image);
        Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
        RectangleF rectf = new RectangleF(70, 90, 90, 50);
        Color color = Color.FromArgb(255, 255, 0, 0);
        try
        {
            if (TColor.ToUpper() == "RED")
            {
                color = Color.FromArgb(255, 255, 0, 0);
            }
            else if (TColor.ToUpper() == "WHITE")
            {
                color = Color.FromArgb(255, 255, 255, 255);
            }
            else if (TColor.ToUpper() == "BLACK")
            {
                color = Color.FromArgb(155, 0, 0, 0);
            }
            else if (TColor.ToUpper() == "GREEN")
            {
                color = Color.FromArgb(255, 0, 255, 0);
            }
        }
        catch { }
        
        //     WHITE (255, 255, 255, 255)
        //     RED	 (255, 255, 000, 000)
        //     GREEN (255, 000, 255, 000)
        //     BLUE	 (255, 000, 000, 255) 
        //     BLACK (150, 000, 000, 000)
        //     PURPLE(255, 125, 000, 255)
        //     GREY	 (255, 128, 128, 128) 
        //     YELLOW(255, 255, 255, 000) 
        //     ORANGE(255, 255, 125, 000)
        
     //   Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);
        Point atpoint = new Point(bitmap.Width / 2, bitmap.Height - 10);
        SolidBrush brush = new SolidBrush(color);
        Graphics graphics = Graphics.FromImage(bitmap);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        graphics.DrawString(watermarkText, font, brush, atpoint, sf);
        graphics.Dispose();
        MemoryStream m = new MemoryStream();
        bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
     //   Response.WriteFile("images/DefaultLogo.png", true);
        m.WriteTo(Response.OutputStream);
        
        m.Dispose();
        base.Dispose();
    }
