    public ActionResult GetImage(string fileName)
    {
        if (!String.IsNullOrEmpty(fileName))
        {
            using (WebClient wc = new WebClient())
            {                   
                var byteArr= wc.DownloadData(fileName);
                return File(byteArr, "image/png");
            }
        }
        return Content("No file name provided");
    }
