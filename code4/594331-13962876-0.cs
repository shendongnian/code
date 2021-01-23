    public ActionResult Index()
    {
        HomeModel model = new HomeModel();
    
        model.Template = db.Templates.ToList();
    
        return View(model);
    }
