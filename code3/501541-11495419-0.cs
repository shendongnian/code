    Example:
    
    System.Web.HttpContext.Current.Application.Lock();
    System.Web.HttpContext.Current.Application["NHSessionFactory"] = "Something";
    System.Web.HttpContext.Current.Application.UnLock();
