    public Byte[] BitmapToArray(Bitmap bitmap)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Bmp);
            return stream.ToArray();
        }
    }
    public Bitmap DownloadImage(String url)
    {
        WebClient client = new WebClient();
        Byte[] bytes = client.DownloadData(url);
    
        Bitmap bitmap = null;
        using (MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length))
        {
            stream.Write(bytes, 0, bytes.Length);
            return (new Bitmap(stream));
        }
    }
    public Byte[] UploadImage(String url, String path)
    {
        WebClient client = new WebClient();
        return client.UploadFile(url, path);
    }
