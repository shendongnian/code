    public ActionResult Thumb(int id)
    {
        using (var client = new WebClient())
        {
            byte[] image = client.DownloadData("http://cdn.foo.com/myimage.jpg");
            return File(image, "image/jpg");
        }
    }
