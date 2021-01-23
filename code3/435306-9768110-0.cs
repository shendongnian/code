    [WebMethod(Description = "SomeDesc.", MessageName = "LoginRSA")]
    public LoginResult LoginRSA(string loginId, string password, string tenant)
    {
        string agent = this.Context.Request.Headers["AgentGUID"];
    }
