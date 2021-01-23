     public ActionResult Index()
            {
                DataTable dt = GetData();
    
                return View(dt);
            }
