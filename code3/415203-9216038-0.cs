    private void DoStuff()
    {
        //...Do Something
    }
    
    public ActionResult MyMethod(MyViewModel myViewModel)   
    {  
       //...Some logic
       DoStuff();  
    
       return RedirectToAction("SecondMethod", new { ... pupulating view model ... });  
    }   
    
    [HttpGet]
    public ActionResult SecondMethod()  
    {  
        return RedirectToAction("Index", "SomeOtherController");  
    }
    
    [HttpPost]
    public ActionResult SecondMethod(MyViewModel myViewModel)  
    {  
       DoStuff();
       return View("MyView", myViewModel);  
    }
