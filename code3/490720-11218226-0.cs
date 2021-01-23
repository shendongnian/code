            PrincipalContext domain = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(domain, userName);
            foreach (GroupPrincipal group in user.GetAuthorizationGroups())
            {
                if (group.Context.ConnectedServer == serverName)
                    Console.Out.WriteLine("{0}\\{1}", group.Context.Name, group.SamAccountName);
            }
