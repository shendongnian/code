    [HttpGet]
    public ActionResult Index()
    {
        Person model = new Person {Name = "foo", Age = 44};
        return View(model);
    }
