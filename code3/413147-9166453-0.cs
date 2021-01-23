    [HttpGet]
    public ActionResult Create(tbl_one tbl_one)
    {
        return View(new tbl_one());
    }
