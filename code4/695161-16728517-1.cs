    if (ModelState.IsValid)
    {
       if (UserAuthenticationManager.IsUniqueByEmail(model.Id, model.Email))
       {
          // do update
       }
       else
       {
          ModelState.AddModelError("", "The user email already exists");
       }
    }
