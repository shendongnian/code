    public ActionResult Index()
    {
      MyModel myModel = new MyModel()
      {
       RadioButtonList = getListFromDB();
       SomeProperty  = valuse		
      };
    
      return View(myModel);
    }
