    using (var entry = new DirectoryEntry("LDAP://foo.net/DC=appName,DC=domainName,DC=com", Username, Password)) {
        using (var searcher = new DirectorySearcher()) {
            searcher.Filter = "(&(objectClass=user))";
            searcher.SearchRoot = entry;
            searcher.PageSize = 5000;
            searcher.PropertiesToLoad.Add(DirectoryConstants.AD_PROPERTY_MEMBER_OF);
            searcher.PropertiesToLoad.Add(DirectoryConstants.AD_PROPERTY_DISPLAY_NAME);
            foreach (SearchResult sr in searcher.FindAll()) {
                //The memberOf property will be a string array if the user is in multiple groups.
                string[] memberOf = GetSearchResultProperties(sr, DirectoryConstants.AD_PROPERTY_MEMBER_OF);
                //Check if the user is in the group by analyzing the string.
                var group = memberOf.FirstOrDefault(m => m.StartsWith(string.Format("CN={0},", groupName)));
                if (group != null) {
                    //The user is in the group!
                }
            }
        }
    }
