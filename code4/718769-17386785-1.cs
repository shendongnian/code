    [HttpPost]
    public JsonResult post()
    {
        return Json("output",JsonRequestBehavior.AllowGet);
    }
    public string post()
    {
        return "output";
    }
