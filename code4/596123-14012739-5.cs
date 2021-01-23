    public User CurrentUser
    {
        get
        {
            var httpContextHelper = DependencyResolver
                .Current
                .GetService<IHttpContextHelper>();
            return httpContextHelper.GetUser();
        }
    }
