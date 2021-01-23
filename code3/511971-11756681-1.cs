    public static Bitmap BytesToBitmap(byte[] byteArray)
    {
        using (var ms = new MemoryStream(byteArray))
        {
            var img = (Bitmap)Image.FromStream(ms);
            return img;
        }
    }
