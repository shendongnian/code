    public ActionResult CreateUser(FormCollection fc)
     {
    
        UserModel usermodel= new UserModel ();
    
        if(TryUpdateModel(usermodel,fc.ToValueProvider()))
     
            UpdateModel(usermodel, fc.ToValueProvider());
    
      return View("UserView"); 
    }
