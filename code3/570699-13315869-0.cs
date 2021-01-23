    public ActionResult Upload(HttpPostedFileBase file)
    {
        using(var stream = file.InputStream)
        {
             ...
        }
    }
