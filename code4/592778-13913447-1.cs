    public static Bitmap ByteToImage(byte[] blob)
    {
        using (MemoryStream mStream = new MemoryStream())
        {
             mStream.Write(blob, 0, blob.Length);
             mStream.Seek(0, SeekOrigin.Begin);
       
             Bitmap bm = new Bitmap(mStream);
             return bm;
        }
    }
