     public static Dictionary<string, DateTime> UsersLastLogOnDate()
       {
           var lastLogins = new Dictionary<string, DateTime>();
           DomainControllerCollection domains = Domain.GetCurrentDomain().DomainControllers;
           foreach (DomainController controller in domains)
           {
               try
               {
                   using (var directoryEntry = new DirectoryEntry(string.Format("LDAP://{0}", controller.Name)))
                   {
                       using (var searcher = new DirectorySearcher(directoryEntry))
                       {
                           searcher.PageSize = 1000;
                           searcher.Filter = "(&(objectClass=user)(!objectClass=computer))";
                           searcher.PropertiesToLoad.AddRange(new[] { "distinguishedName", "lastLogon" });
                           foreach (SearchResult searchResult in searcher.FindAll())
                           {
                               if (searchResult.Properties.Contains("lastLogon"))
                               {
                                   var lastLogOn = DateTime.FromFileTime((long)searchResult.Properties["lastLogon"][0]);
                                   var username = Parser.ParseLdapAttrValue(searchResult.Properties["distinguishedName"][0].ToString());
                                   if (lastLogins.ContainsKey(username))
                                   {
                                       if (DateTime.Compare(lastLogOn, lastLogins[username]) > 0)
                                       {
                                           lastLogins[username] = lastLogOn;
                                       }
                                   }
                                   else
                                   {
                                       lastLogins.Add(username, lastLogOn);
                                   }
                               }
                           }
                       }
                   }
                   
               }
               catch (System.Runtime.InteropServices.COMException comException)
               {
                   // Domain controller is down or not responding
                   Log.DebugFormat("Domain controller {0} is not responding.",controller.Name);
                   Log.Error("Error in one of the domain controllers.", comException);
                   continue;
               }
           }
           return lastLogins;
       }
