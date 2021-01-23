    public ActionResult AddDetail(string Key)
    {
        ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("{0}", key)
        return View(key);
    }
