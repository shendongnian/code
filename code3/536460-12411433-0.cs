    [HttpPost]
    public ActionResult Index()
    {
        ViewBag.MyLabelUpdate = "whatever";
        return RedirectToAction("Index");
    }
