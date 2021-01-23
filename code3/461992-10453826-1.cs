    using System.DirectoryServices;
    using System.Diagnostics;
    using System.Management;
    using System.DirectoryServices.AccountManagement;
    public bool IsAuthenticated(String domain, String username, String pwd)
    {
        // this is a query of the students credentials
        try
        {
            //Bind to the native AdsObject to force authentication.		            
            String domainAndUsername = domain + "\\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }
            //Update the new path to the user in the directory.
            _path = result.Path;
            _filterAttribute = (String)result.Properties["cn"][0];
        }
        catch (Exception ex){}
        return true;
    }
