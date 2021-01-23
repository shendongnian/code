    public static List<string> getGroups(string userName)          
    {          
        List<string> adGroups = new List<string>();          
        try          
        {
            var currentUser = UserPrincipal.Current;
                        
            PrincipalSearchResult<Principal> groups = currentUser.GetGroups();          
            IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);          
            foreach (var name in groupNames)          
            {          
                adGroups.Add(name.ToString());          
            }          
            return adGroups;          
        }          
        catch (Exception ex)          
        {          
                   
        }          
    }
