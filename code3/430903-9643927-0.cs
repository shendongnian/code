    public ActionResult GetImg()
    {
        WebClient client = new WebClient();
        byte[] imgContent = client.DownloadData("ImgUrl");
        WebImage img = new WebImage(imgContent);
        img.Resize(200,300);
        img.Write();
        return null;
    }
