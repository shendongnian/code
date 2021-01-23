    public ActionResult Index(bool? isJson)
    {
        if (isJson.HasValue && isJson.Value)
        {
            return Json();
        }
        return View();
    }
