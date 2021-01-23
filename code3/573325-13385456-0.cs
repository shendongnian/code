    public static Bitmap ToBitmap(this byte[] bits)
    {
        using (MemoryStream stream = new MemoryStream(bits))
        {
            return new Bitmap(stream);
        }
    }
