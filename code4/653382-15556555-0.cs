           try
            {
                //Get the manager name from the active directory
                var domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                using (DirectoryEntry dir = new DirectoryEntry("LDAP://" + domain))
                {
                    using (DirectorySearcher ds = new DirectorySearcher(dir, "samAccountName=" + requster))
                    {
                        SearchResult sr = ds.FindOne();
                        //Exeception occurs on this line below, if the attribute is not set.
                        string managerName = sr.Properties["Manager"][0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
