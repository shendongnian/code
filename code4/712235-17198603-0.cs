    [HttpPost]
    public ActionResult DoSomething(Container container){
       var error = Model.GetErrors();  //Change this to whatever call you need to validate the Container
       if(error.HasErrors)
       {
           ModelState.AddModelError("KEY",error.Message);
       }
    
       return view(container);
    }
