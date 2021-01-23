    private string GetConvertedPNGFile(string imagename)
    {
        var bitmap = Bitmap.FromFile(imagename);
        b.Save(Path.GetFileName(imagename) + ".png", ImageFormat.Png);
        return Path.GetFileName(imagename) + ".png";
    }
