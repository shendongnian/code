    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));  
    Response.Cache.SetCacheability(HttpCacheability.NoCache);  
    Response.Cache.SetNoStore();  
    Session.Abandon();
    FormsAuthentication.SignOut();
    FormsAuthentication.RedirectToLoginPage();
