    [HttpGet]
    public ActionResult Foo()
    {
    	var model = new FooContainer();
    	return View("Foo", model);
    }
    
    [HttpPost]
    public ActionResult Foo(FooContainer model)
    {
    	ViewBag.Test = m.Foos[1].Name;
    	return View("Foo", model);
    }
