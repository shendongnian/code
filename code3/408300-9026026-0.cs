    [RequireHttps]
    [HttpPost]
    public ActionResult LogOn(LogOnModel model, string returnUrl)
    {
          if (ModelState.IsValid)
          {
               UserProfile profile = UserProfile.GetUserProfile(model.UserName); // Moved this here because locking check should be done before ValidateUser()
               if (profile != null && !profile.IsLockedOut)
               {
    
                    if (MembershipService.ValidateUser(model.UserName, model.Password))
                    {
                         FormsService.SignIn(model.UserName, model.RememberMe);
    
                     //.... 
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
            }
            else
            {
               ModelState.AddModelError("", "The user account does not exist or has been locked out.");
            }
       }
    
       return View(model);
    }
