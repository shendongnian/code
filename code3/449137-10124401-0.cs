    [HttpGet]
    public ActionResult List() {
        ViewBag.Error = TempData["Error"];
        // ...
        return View();
    }
