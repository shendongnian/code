    [HttpPost]
    public ActionResult Test()
    {
        string value = "hello";
        return Json(value);
    }
