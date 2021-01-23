    public IPrincipal User
    {
        get
        {
            if (HttpContext != null)            
                return HttpContext.User;
            
            return null;
        }
    }
