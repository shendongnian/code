                  PrincipalContext ouContex = new PrincipalContext(ContextType.Domain, "TestDomain.local",           "OU=TestOU,DC=TestDomain,DC=local");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    UserPrincipal up = new UserPrincipal(ouContex);
                    up.SamAccountName = "TestUser" + i;
                    up.SetPassword("password");
                    up.Enabled = true;
                    up.ExpirePasswordNow();
                    up.Save();
                }
                catch (Exception ex)
                {
                }
            }
