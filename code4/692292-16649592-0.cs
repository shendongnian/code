    string userName = null;
    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
    {
        userName = filterContext.HttpContext.User.Identity.Name;
    }
