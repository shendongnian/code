    [HttpGet]
    public ActionResult ChangeLabelText()
    {
        return View();
    }
    [HttpPost]
    public ActionResult ChangeLabelText(FormCollection formCollection)
    {
        ViewBag.LastNameEntered = formCollection["txtName"];
        return View();
    }
