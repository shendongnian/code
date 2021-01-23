    public ActionResult Search()
    {
        dynamic searchParams = Request.QueryString.ToExpando();
        
        DoSomething(searchParams.name);  
        var model = getResults(searchParams);
        return View(model);
    }
