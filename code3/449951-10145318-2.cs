    public ActionResult Foo(string id)
    {
        var person = Something.GetPersonByID(id);
        return Json(person, JsonRequestBehavior.AllowGet);
    }
