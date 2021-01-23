    public ActionResult CreateUser(CreateUserViewModel model)
    {
       if(ModelState.IsValid)
       {
          string username = model.UserName;
          //... etc
    
          bool created = MyModelClass.Create(username, ...);
       }
    
    }
