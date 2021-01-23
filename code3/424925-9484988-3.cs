    public Bitmap CropImage(Bitmap source, Rectangle section)
    {
        // An empty bitmap which will hold the cropped image
        Bitmap bmp = new Bitmap(section.Width, section.Height);
     
        Graphics g = Graphics.FromImage(bmp);
     
        // Draw the given area (section) of the source image
        // at location 0,0 on the empty bitmap (bmp)
        g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
     
        return bmp;
    }
     
    // Example use:     
    Bitmap source = new Bitmap(@"C:\tulips.jpg");
    Rectangle section = new Rectangle(new Point(12, 50), new Size(150, 150));
     
    Bitmap CroppedImage = CropImage(source, section);
