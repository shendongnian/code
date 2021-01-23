    public ActionResult Index()
      {
                using (NORTHWNDEntities c = new NORTHWNDEntities())
                {
    
                    var x = c.Employees.Count();
                    var model = new MyModel{Count = x};    
                    return View(model);       
                }
        }
