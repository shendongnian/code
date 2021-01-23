    public ActionResult Index()
    {
        var serializer = new JavaScriptSerializer();
        var vm = new IndexViewModel
        {
             ShowWelcomeMsg = serializer.Serialize(true)
        };
        return View(vm);
    }
