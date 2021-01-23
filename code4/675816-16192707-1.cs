          List<User> user = null;
          if(HttpContext.Current.Application["loggedUsers"] == null)
          {
             user = new List<User>();
          }
          else
          {
             user = (List<User>)HttpContext.Current.Application["loggedUsers"]; 
          }
       
