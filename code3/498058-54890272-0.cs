    public Bitmap OpenImage(string filePath)
    {
        using (Bitmap tmpBmp = (Bitmap)Image.FromFile(filePath))
        {
            return new Bitmap(tmpBmp);
        }
    }
