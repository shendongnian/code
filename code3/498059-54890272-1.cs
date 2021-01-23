    public Bitmap OpenImage(string filePath)
    {
        using (var stream = System.IO.File.OpenRead(filePath))
        {
            return (Bitmap)System.Drawing.Image.FromStream(stream);
        }
    }
