    public JsonResult GetRevisions(int id)
    {
        ReturnArg r = new ReturnArg();
        r.header.Add("title", "Test");
        r.header.Add("num", 5);
        r.header.Add("limit", 5);
        r.data.Add("primary", "Primary");
        ...
        return Json(r);
    }
