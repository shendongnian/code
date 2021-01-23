    [OutputCache(Duration = 60, VaryByCustom = "host")]
    public ActionResult Foo()
    {
        return View();
    }
