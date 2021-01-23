    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        using(MemoryStream ms = new MemoryStream()) 
        {
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.MemoryBmp);
            return ms.ToArray();
        }
    }
