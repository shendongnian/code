       /// <summary>
       /// Account controller.
       /// </summary>
    
          public ActionResult LogOn()
          {
             LogOnModel logOnModel = new LogOnModel();
    
             HttpCookie existingCookie = Request.Cookies["userName"];
             if (existingCookie != null)
             {
                logOnModel.UserName = existingCookie.Value;
             }
    
             return View(logOnModel);
          }
        
        
          public ActionResult LogOn(LogOnModel model, string returnUrl)
          {
             if (model.RememberMe)
             {
                // check if cookie exists and if yes update
                HttpCookie existingCookie = Request.Cookies["userName"];
                if (existingCookie != null)
                {
                   // force to expire it
                   existingCookie.Value = model.UserName;
                   existingCookie.Expires = DateTime.Now.AddHours(-20);
                }
    
                // create a cookie
                HttpCookie newCookie = new HttpCookie("userName", model.UserName);
                newCookie.Expires = DateTime.Today.AddMonths(12);
                Response.Cookies.Add(newCookie);
             }
    
         
             // If we got this far, something failed, redisplay form
             return View(model);
          }
