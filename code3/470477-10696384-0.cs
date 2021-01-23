    string filepath = img1.ImageUrl;           
    using (WebClient client = new WebClient())
    {
           client.DownloadFile(filepath,Server.MapPath("~/Image/apple.jpg"));
    }
