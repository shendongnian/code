    [AutoMap(typeof(Bar), typeof(BarViewModel))]
    public ActionResult Foo(int id)
    {
        Bar domainModel = Repository.Get(id);
        return View(domainModel);
    }
