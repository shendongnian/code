    private DefaultConnection db = new DefaultConnection();
    public ActionResult Index()
    {
        var drop = new MyviewModel 
        {
            MyObjs = db.MyObjs,// selecting table...
            Other = new Other
        }
        return View(drop);
    }
