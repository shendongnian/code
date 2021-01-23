    public ActionResult Read(int id)
    {
        var obj = RavenSession.Load<MyClass>(id);
        return View(obj);
    }
