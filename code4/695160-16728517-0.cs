    if (ModelState.IsValid)
    {
       if (UserAuthenticationManager.IsUniqueByEmail(model.Email))
       {
          // do update
       }
       else
       {
          ModelState.AddModelError("", "The user email already exists");
       }
    }
