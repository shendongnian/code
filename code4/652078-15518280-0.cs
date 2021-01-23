    Session.Abandon();
    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
    SessionIDManager manager = new SessionIDManager();
    manager.RemoveSessionID(System.Web.HttpContext.Current);
    var newId = manager.CreateSessionID(System.Web.HttpContext.Current);
    var isRedirected = true;
    var isAdded = true;
    manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedirected, out isAdded);
    Response.Redirect("Login page url");
