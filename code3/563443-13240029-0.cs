    private static Bitmap ConvertTo24(Bitmap bmpIn)
    {
        //Bitmap bmpIn;
        bmpIn = new Bitmap(@"f:\sara1.bmp");
        Bitmap converted = new Bitmap(bmpIn.Width, bmpIn.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(converted))
        {
             g.PageUnit = GraphicsUnit.Pixel;
             Rectangle rng = new Rectangle(new Point(0, 0), bmpIn.Size);
             g.DrawImage(bmpIn, rng);  // use this instead of following
        }
        converted.Save(@"F:\sara2.bmp");
    }
