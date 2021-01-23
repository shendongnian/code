    public Byte[] Set(String url, String path)
    {
        WebClient client = new WebClient();
        return client.UploadFile(url, path);
    }
    public Image GetImage(String url)
    {
        WebClient client = new WebClient();
        Byte[] bytes = client.DownloadData(url);
    
        Image image = null;
        using (MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length))
        {
            stream.Write(bytes, 0, bytes.Length);
            image = Image.FromStream(stream, true);
            stream.Close();
        }
    
        return image;
    }
