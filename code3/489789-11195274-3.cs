    public byte[] ImageToByte(Bitmap image){
        using (MemoryStream ms = new MemoryStream())
        {
            // Convert Image to byte[]
            image.Save(ms, ImageFormat.Bmp);
            byte[] imageBytes = ms.ToArray();
            return imageBytes;
        }
    }
