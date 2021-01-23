    public JsonResult Hello()
    {
        A obj = new A();
        obj.Name = "Abc";
        return Json(new { obj }, JsonRequestBehavior.AllowGet);
    }
