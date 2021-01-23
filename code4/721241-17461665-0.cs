    public override void OnAuthenticated(
            IServiceBase authService,
            IAuthSession session,
            IOAuthTokens tokens,
            Dictionary<string, string> authInfo)
    {
        base.OnAuthenticated(authService, session, tokens, authInfo);
        // access servicestack user server and load properies for session here
        var userService = authService.TryResolve<UserService>();
        CurrentUser = (User)userService.Get(new GetUser(SteamID));
    }
