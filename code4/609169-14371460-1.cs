    public ActionResult Index(string id)
    {
        ContentResult cr = new ContentResult();
        // Do a DB lookup here to get the data you need from the database to generate the appropriate content.
        cr.Content = id;
        return cr;
    }
