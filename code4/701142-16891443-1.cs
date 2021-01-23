    public ActionResult Images(string file)
    {
        path = "/Projects/test/images/" + file;
        if (!System.IO.File.Exists(path))
        {
            return new HttpNotFoundResult();
        }
        return File(path, "image/jpeg");
    }
