    [HttpGet]
    public ActionResult Create()
    {
        // Setup model before passing in
        var model = new Bond();
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(Bond position)
    {
        string theValue = position.Kauf.Value;
        // At this point "theValue" contains a valid item
        return View(position);
    }
