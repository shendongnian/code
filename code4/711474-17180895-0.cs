    static void Main(string[] args)
    {
        var path = @"gdi_err.jpg";
        using (var img1 = Image.FromFile(path))
        using (var ms1 = new MemoryStream())
        {
            img1.Save(ms1, ImageFormat.Bmp);
            ms1.Position = 0;
            using (var img2 = Image.FromStream(ms1))
            using (var ms2 = new MemoryStream())
            {
                img2.Save(ms2, ImageFormat.Jpeg);
            }
        }
    }
