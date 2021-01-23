    if (HttpContext.Current.User != null)
      {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
         if (HttpContext.Current.User.Identity is FormsIdentity)
         {
             .....
         }
        }
      }
