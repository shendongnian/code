    public ActionResult Index()
      { 
                    EmployeeService srvc = new EmployeeService();
                    var x = srvc.GetEmployeeCount();
                    var model = new MyModel{Count = x};    
                    return View(model);   
      }
