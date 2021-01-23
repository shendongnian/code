    public ActionResult StatePartial()
    {
        ViewBag.MyData = new string[] { "110", "24500" };
        return View("_StatePartial");
    }
