    string domainControllerName = "PDC";
    string domainName = "MyDomain"; // leave out the .Local, this is just to use as the prefix for the username if the user left it off or didn't use the principal address notation
    string username = "TestUser";
    string password = "password";
    using (var ldap = new PrincipalContext(ContextType.Domain, domainControllerName))
    {
        var usernameToValidate = username;
        if (!usernameToValidate.Any(c => c == '@' || c == '\\'))
                usernameToValidate = $"{domainName}\\{username}";
        if (!ldap.ValidateCredentials(username, context.Password, ContextOptions.SimpleBind))
            throw new UnauthorizedException();
    }
