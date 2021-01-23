    private static Bitmap ConvertTo24(Bitmap bmpIn)
    {
        bmpIn.Save(@"F:\sara1.bmp");
        return;
        // After you have called this function. Go open your image f:\sara1.bmp from
        //hrad disk-- I doubt you would find it shifted here even before conversion
        Bitmap converted = new Bitmap(bmpIn.Width, bmpIn.Height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(converted))
        {
             // Prevent DPI conversion
             g.PageUnit = GraphicsUnit.Pixel;
             // Draw the image
             g.DrawImageUnscaled(bmpIn, 0, 0);
             // g.DrawImage(bmpIn, 0, 0);
        }
        converted.Save(@"F:\sara2.bmp");
    }
