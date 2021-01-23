    public Bitmap CropImage(Bitmap source, Rectangle section)
    {
        var bitmap = new Bitmap(section.Width, section.Height);
        using (var g = Graphics.FromImage(bitmap))
        {
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            return bitmap;
        }
    }
     
    // Example use:     
    Bitmap source = new Bitmap(@"C:\tulips.jpg");
    Rectangle section = new Rectangle(new Point(12, 50), new Size(150, 150));
     
    Bitmap CroppedImage = CropImage(source, section);
