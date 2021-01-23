    public static List<string> getGrps(string userName)          
    {          
        List<string> grps = new List<string>();          
    
        try          
        {
            var currentUser = UserPrincipal.Current;
            RevertToSelf();             
            PrincipalSearchResult<Principal> groups = currentUser.GetGroups();          
            IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);          
            foreach (var name in groupNames)          
            {          
                grps.Add(name.ToString());          
            }          
            return grps;          
        }          
        catch (Exception ex)          
        {          
            // Logging         
        }          
    } 
