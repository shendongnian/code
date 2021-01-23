    public void ProcessRequest(HttpContext context)
    {
        string url = "https://............10000.JPG";
        byte[] imageData;
        using (WebClient client = new WebClient())
        {
            imageData = client.DownloadData(url);
        }
        context.Response.OutputStream.Write(imageData, 0, imageData.Length);
    }
