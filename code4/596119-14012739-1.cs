    public User CurrentUser
    {
        get
        {
            var httpContextHelper = DependencyResolver.Current.GetService<HttpContextHelper>();
            return httpContextHelper.GetUser();
        }
    }
