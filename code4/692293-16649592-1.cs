    string userName = null;
    if (HttpContext.Current.User.Identity.IsAuthenticated)
    {
        userName = HttpContext.Current.User.Identity.Name;
    }
