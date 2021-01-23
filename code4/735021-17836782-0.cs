    public byte[] SaveImage(BitmapSource bitmap)
    {
        using (MemoryStream MS = new MemoryStream())
        {
            BmpBitmapEncoder Encoder = new BmpBitmapEncoder();
            Encoder.Frames.Add(BitmapFrame.Create(bitmap));
            Encoder.Save(MS);
            return MS.GetBuffer();
        }
    }
