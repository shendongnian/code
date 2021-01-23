    public ActionResult GridData(string name)
    {
       var gridItems=repo.GetCustomers(name).ToList();   
       //the above method can be replaced by your 
       // actual method which returns the data for grid
       
        return View(model);
    }
