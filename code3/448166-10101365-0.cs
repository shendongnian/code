    public ActionResult MyAction()
    {
       var houses = GetFullList();
    
       foreach(var house in houses)
       {
          // here you can access the properties of the 
          // current house in the loop.
       }
    }
