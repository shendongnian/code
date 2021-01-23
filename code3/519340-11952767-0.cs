     private bool LoginS(string userName, string password)
            {
                bool authentic = false;
                try
                {
                    DirectoryEntry entry = new DirectoryEntry(LDAP-PAth, userName, password, AuthenticationTypes.Secure);
                    authentic = true;
    
                   
                    Console.WriteLine("Authentification succesful");
    
                }
                catch (DirectoryServicesCOMException e)
                {
                    _logger.Error("Authentification error", e);
                    //User doesnt exist or input is false
    
                }
                return authentic;
            }
