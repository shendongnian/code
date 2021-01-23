    public bool ActiveDirectoryAuthentication(string username, string password)
        {
            var splittedCredentials = username.Split(new[] { "\\" }, StringSplitOptions.None);
            switch (splittedCredentials.Length)
            {
                case 1:
                    {
                        var authenticated = Membership.ValidateUser(username, password);
                        if (authenticated)
                        {
                            FormsAuthentication.SetAuthCookie(username, false);
                        }
                        return authenticated;
                    }
                case 2:
                    {
                        var principalContext = new PrincipalContext(ContextType.Domain, splittedCredentials[0]);
                        using (principalContext)
                        {
                            var authenticated = principalContext.ValidateCredentials(splittedCredentials[1], password);
                            if (authenticated)
                            {
                                FormsAuthentication.SetAuthCookie(splittedCredentials[1], false);
                            }
                            return authenticated;
                        }
                    }
                default:
                    return false;
            }
        }
