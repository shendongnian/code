    HttpContext.Response.Headers.Add("CustomRoute", "1");
    return RedirectToRoute("MyRouteName");
...
    public bool IsRouteRequested()
    {
       if (HttpContext.Response.Headers["CustomRoute"] != null &&
           HttpContext.Response.Headers["CustomRoute"] == "1")
           return true;  
    
       return false;
    
    }
