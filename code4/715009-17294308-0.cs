            using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "DOMAINNAME"))
            {
                using(UserPrincipal qbeUser = new UserPrincipal(ctx))
                {
                    using (PrincipalSearcher srch = new PrincipalSearcher(qbeUser))
                    {
                        foreach (var found in srch.FindAll())
                        {
                            var user = (UserPrincipal)found;
                            Console.WriteLine(user.GivenName + " " + user.Surname +  " " + user.EmailAddress);
                        }
                    }
                }
            }
