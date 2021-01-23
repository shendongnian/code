    public ActionResult Index(int id)
    {
        MyModel _Model = DAL.LoadMyModel(id); 
        return View(_Model);
    }
