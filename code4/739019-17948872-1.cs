    public ActionResult Index()
    {
        var drop = new MyviewModel 
        {
            MyObjs = db.MyObjs,
            Other = new Other
        }
        return View(drop);
    }
