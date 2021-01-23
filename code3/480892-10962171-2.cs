    private  int GetImageWidth(string url)
    {
        int width = 0;
        using (WebClient client = new WebClient())
        {
            client.Credentials = new NetworkCredential("name", "pw");
            byte[] imageBytes = client.DownloadData(url);
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                var img = Image.FromStream(stream);
                width=  img.Width;
            }
        }
        return width;
    }
