     private bool LoginS(string userName, string password)
            {
                bool authentic = false;
                try
                {
                    DirectoryEntry entry = new DirectoryEntry(LDAP-Path, userName, password, AuthenticationTypes.Secure);
                    authentic = true;
    
                   
                    Console.WriteLine("Authentication successful");
    
                }
                catch (DirectoryServicesCOMException e)
                {
                    _logger.Error("Authentification error", e);
                    //User doesnt exist or input is false
    
                }
                return authentic;
            }
