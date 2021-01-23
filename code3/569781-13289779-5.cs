    [HttpPost]
    public ActionResult Test()
    {
        string value = LoginClass.test();
        return Json(value);
    }
