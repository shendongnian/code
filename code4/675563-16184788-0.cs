    string userName = string.Empty;
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "Your Domain Name")) 
                {
                    UserPrincipal user = new UserPrincipal(pc);
                    user = UserPrincipal.FindByIdentity(pc, "User ID Will Come here");
                    if (user != null)
                    {
                        userName = user.GivenName + " " + user.Surname;
    
                    }
                    else
                    {
                        //return string.Empty;
                        userName = "User Not Found";
                    }
                }
