    //Add a reference on System.DirectoryServices.dll
        using System.DirectoryServices;    
        //Connect to your LDAP
        DirectoryEntry Ldap = new DirectoryEntry("LDAP://ADName", "Login", "Password");
        DirectorySearcher searcher = new DirectorySearcher(Ldap);
        //specify that you search user only by filtering AD objects
        searcher.Filter = "(objectClass=user)";
        //Loop on each users
         foreach( SearchResult result in searcher.FindAll() )
            {
               // On récupère l'entrée trouvée lors de la recherche
               DirectoryEntry DirEntry = result.GetDirectoryEntry();
               	
               //On peut maintenant afficher les informations désirées
               Console.WriteLine("Login : " + DirEntry.Properties["SAMAccountName"].Value);
               Console.WriteLine("FirstName: " + DirEntry.Properties["sn"].Value);
               Console.WriteLine("LastName: " + DirEntry.Properties["givenName"].Value);
               Console.WriteLine("Email : " + DirEntry.Properties["mail"].Value);
               Console.WriteLine("Phone: " + DirEntry.Properties["TelephoneNumber"].Value);
               Console.WriteLine("Description : " + DirEntry.Properties["description"].Value);
            				
               Console.WriteLine("-------------------");
            }
