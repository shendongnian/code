    string userName = "David";
    string GroupName = "Team 1";
    bool test = IsMember(userName, GroupName);
-----------
    
        public static bool IsMember(string UserName, string GroupName)
        {
            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(
                    new PrincipalContext(ContextType.Domain),
                    UserName);
                foreach (Principal result in user.GetAuthorizationGroups())
                {
                    if (string.Compare(result.Name, GroupName, true) == 0)
                        return true;
                }
                return false;
            }
            catch (Exception E)
            { 
                throw E; 
            }
        }
