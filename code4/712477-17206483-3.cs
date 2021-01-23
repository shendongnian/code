    public ActionResult CreateUser(CreateUserViewModel model)
    {
       if(ModelState.IsValid)
       {
          string username = model.UserName;
          //... etc
    
          bool created = MyUserModelClass.Create(username, ...);
          if(created)
              Return RedirectToAction("Index");
          else
              return View(model); //return the form
       }
       else
       {
          return View(model); //return the form
       }
    }
