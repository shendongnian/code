    public ActionResult GetImage(string fileName)
    {
        if (!String.IsNullOrEmpty(fileName))
        {
            return File(downloadFile(fileName, 2048), "image/png");
        }
        return Content("No file name provided");
    }
