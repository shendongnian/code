    private Bitmap getScreen(NetworkStream Nw, Byte[] dataByte, int thisRead, int Blocksize)
    {
        Bitmap bitmap;
        using (var strm = new MemoryStream())
        {
            while (true)
            {
                thisRead = Nw.Read(dataByte, 0, Blocksize);
                strm.Write(dataByte, 0, thisRead);
                if (thisRead == 0)
                   break;
            }
            stream.Seek(0, SeekOrigin.Begin; // <-- Go Back to beginning of stream
            bitmap = new Bitmap(strm); // Error here
        }
        Bitmap bm3 = new Bitmap(bitmap);
        bitmap.Dispose();
        return bm3;
    }
