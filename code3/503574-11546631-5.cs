    public ActionResult Foo()
    {
        var model = new MyViewModel
        {
            Foo = 123,
            Bar = "abc"
        };
        return Json(model, JsonRequestBehavior.AllowGet);
    }
