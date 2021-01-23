    public ActionResult Foo()
    {
        var list = new List<string>();
        list.Add("foo");
        list.Add("bar");
    
        return Json(list, JsonRequestBehavior.AllowGet);
    }
