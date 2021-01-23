            string user = "username";
            //get domain
            DirectoryEntry de = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().GetDirectoryEntry();
            //get users dn first
            string userDN;
            using (var searcher = new DirectorySearcher(de))
            {
                searcher.Filter = String.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", user);
                searcher.PropertiesToLoad.Add("distinguishedName");
                userDN = searcher.FindOne().Properties["distinguishedName"][0].ToString();
            }
            
            //get list of all users groups
            List<string> groups;
            //see http://stackoverflow.com/questions/6252819/find-recursive-group-membership-active-directory-using-c-sharp
            using (var searcher2 = new DirectorySearcher(de))
            {
                searcher2.Filter = String.Format("(member:1.2.840.113556.1.4.1941:={0})", userDN);
                searcher2.SearchScope = SearchScope.Subtree;
                searcher2.PropertiesToLoad.Add("distinguishedName");
                SearchResultCollection src = searcher2.FindAll();
                groups = (from SearchResult c in src
                          select c.Properties["distinguishedName"][0].ToString()).ToList();
            }
            //build giant search query
            SearchResultCollection srcGroups;
            using (var searcher = new DirectorySearcher(de))
            {
                string baseString = "(|{0})";
                string managedbybase = "(managedBy={0})";
                //I've read that you can search multivalued lists using a standard ='s.
                string ourOwnManagedByBase = "(ourOwnManagedBy={0})";
                StringBuilder sb = new StringBuilder();
                //add user DN to list of group dn's
                groups.Add(userDN);
                foreach (string g in groups)
                {
                    sb.AppendFormat(managedbybase, g);
                    sb.AppendFormat(ourOwnManagedByBase, g);
                }
                searcher.Filter = string.Format(baseString, sb.ToString());
                srcGroups = searcher.FindAll();
            }
