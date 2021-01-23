    [HttpGet]
    public ActionResult DeleteAllUsers()
    {
        return View();
    }
    [HttpPost]
    public JsonResult DeleteAllUsers()
    {
        return Json(true);
    }
