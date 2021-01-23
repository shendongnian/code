    public ActionResult Foo()
    {
        var model = new { param1 = "data1", param2 = "data2" };
        return Json(model, JsonRequestBehavior.AllowGet);
    }
