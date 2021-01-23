                //set the principal context to the users domain
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, userDomain);
            //lookup the user id on the domain
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, userId);
            if (up == null)
            {
                Console.WriteLine(string.Format("AD USER NOT FOUND {0}", userGc));
                return;
            }
            //grab the info we need from the domain
            Console.WriteLine(up.ToString());
            DirectoryEntry d = up.GetUnderlyingObject() as DirectoryEntry;
            string managerCN = d.Properties["manager"].Value.ToString(); 
            Console.WriteLine(managerCN);
            UserPrincipal manager = UserPrincipal.FindByIdentity(pc, managerCN);
            Console.WriteLine(manager.EmailAddress);
