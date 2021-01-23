    public ActionResult Foo()
    {
        var model = new MyViewModel
        {
            SomeValue = "Hello world"
        };
        return View(model);
    }
