        public ActionResult ProvinceFilter(LogOnModel model)
        {
          string result=="";    
          UserPrincipal principal = new UserPrincipal(model.EmailAddress, model.Password); //in order to retorn exact error you must modify the principle to check if the user is valid or not and return specific error
         if(principal==null) //or not valid 
          {
             result="Your Username or Password is not correct";
          }
          else
           {
            HttpContext.User = principal;
            FormsAuthentication.SetAuthCookie(model.EmailAddress, true);
            result=principal.UserID.ToString();
           }
            return Json(result);
        }
