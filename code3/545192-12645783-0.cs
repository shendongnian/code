    using (Bitmap bitmap = new Bitmap(500, 500))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            ...
        }
    
        using (var memoryStream = new MemoryStream())
        {
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
    }
