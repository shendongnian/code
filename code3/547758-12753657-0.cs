            int maxWait = 120;
            int cnt = 0;
            bool usable = false;
            while (usable == false && cnt < maxWait)
            {
                try
                {
                    foreach (var group in userPrincipal.GetGroups())
                    {
                        var groupPrincipal = (GroupPrincipal)@group;
                        if (groupPrincipal.Sid != templatePrimaryGroup.Sid)
                        {
                            groupPrincipal.Members.Remove(userPrincipal);
                            groupPrincipal.Save();
                        }
                    }
                    usable = true;
                    break;
                }
                catch
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            if (usable)
                //All okay
                ;
            else
                //Do something
                ;
