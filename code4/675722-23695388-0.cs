         public GetUserByLoginName(String userName)
        {
           
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    // This code runs as the application pool user
                    _directoryEntry = null;
                    string path = "LDAP://xxx.local/DC=xxx,DC=xxx"; //your LDAP Address
                   
                    DirectorySearcher directorySearch = new DirectorySearcher(path);
                    directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";
                    SearchResult results = directorySearch.FindOne();
                   
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
