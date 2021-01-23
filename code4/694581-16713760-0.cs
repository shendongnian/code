                string domainAndUsername = string.Empty;
                string domain = string.Empty;
                string userName = string.Empty;
                string passWord = string.Empty;
                AuthenticationTypes at = AuthenticationTypes.Anonymous;
                StringBuilder sb = new StringBuilder();
    
                domain = @"LDAP://w.x.y.z";
                domainAndUsername = @"LDAP://w.x.y.z/cn=Lawrence E."+
                            " Smithmier\, Jr.,cn=Users,dc=corp,"+
                            "dc=productiveedge,dc=com";
                userName = "Administrator";
                passWord = "xxxpasswordxxx";
                at = AuthenticationTypes.Secure;
    
                DirectoryEntry entry = new DirectoryEntry(
                            domain, userName, passWord, at);
    
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
    
                SearchResultCollection results;
                string filter = "maxPwdAge=*";
                mySearcher.Filter = filter;
    
                results = mySearcher.FindAll();
                long maxDays = 0;
                if(results.Count>=1)
                {
                    Int64 maxPwdAge=(Int64)results[0].Properties["maxPwdAge"][0];
                    maxDays = maxPwdAge/-864000000000;
                }
    
                DirectoryEntry entryUser = new DirectoryEntry(
                            domainAndUsername, userName, passWord, at);
                mySearcher = new DirectorySearcher(entryUser);
    
                results = mySearcher.FindAll();
                long daysLeft=0;
                if (results.Count >= 1)
                {
                    var lastChanged = results[0].Properties["pwdLastSet"][0];
                    daysLeft = maxDays - DateTime.Today.Subtract(
                            DateTime.FromFileTime((long)lastChanged)).Days;
                }
                Console.WriteLine(
                            String.Format("You must change your password within"+
                                          " {0} days"
                                         , daysLeft));
                Console.ReadLine();
            }
