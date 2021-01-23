     public static string getExchangeServerVersion()
            {
                try
                {
                    string domain =Domain.GetCurrentDomain().ToString();
                    DirectoryEntry rootDSE = new DirectoryEntry(string.Format("LDAP://{0}/rootDSE",  domain));
                    DirectoryEntry objDirectoryEntry = new DirectoryEntry(string.Format("LDAP://{0}/{1}",domain,rootDSE.Properties["configurationNamingContext"].Value.ToString()));
                    DirectorySearcher searcher = new DirectorySearcher(objDirectoryEntry, "(&(objectClass=msExchExchangeServer))");
                    SearchResultCollection col = searcher.FindAll();
                    string version = string.Empty;
                    foreach (SearchResult result in col)
                    {
                        DirectoryEntry user = result.GetDirectoryEntry();
                        if (String.Equals(user.Properties["name"].Value.ToString(),Dns.GetHostName(),StringComparison.InvariantCultureIgnoreCase))
                        {
                            version = user.Properties["serialNumber"].Value.ToString();
                            break;
                        }
                    }
                    return version;
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError : " + ex.Message);
                    return "";
                }
            }
     if (exchangeServerVersion.Contains("Version 6"))
            {
                users.GetExchange2003UserList();
                GetADGroupList();
            }
            else if (exchangeServerVersion.Contains("Version 8"))
            {
                users.GetExchange2007UserList();
                GetADGroupList();
            }
            else if (exchangeServerVersion.Contains("Version 14"))
            {
                users.GetExchange2010UserList();
                GetADGroupList();
            }
