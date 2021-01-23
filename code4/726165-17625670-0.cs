    Response.Cookies.Clear();
    
    FormsAuthentication.SignOut();     
    
    HttpCookie c = new HttpCookie("login");
    c.Expires = DateTime.Now.AddDays(-1);
    Response.Cookies.Add(c);
    
    Session.Clear();
