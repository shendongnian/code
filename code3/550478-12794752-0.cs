    public void GetAllWorkstations()
    {
    List<string> objWorkstationNames = new List<string>();
    //Creating Directory Entry object by LDAP Query
    DirectoryEntry objEntry = new DirectoryEntry("LDAP://YourActiveDirectoryDomain.no");
 
    DirectorySearcher objDirectoriesManager = new DirectorySearcher(objEntry);
    //LDAP Query that will surely do the trick, filtering out only workstations/Computer
    objDirectoriesManager.Filter= ("(objectClass=computer)");
    
    //Setting up maximum directory/Computer/Workstations limit
    objDirectoriesManager.SizeLimit= int.MaxValue;
    //Setting up page size
    objDirectoriesManager.PageSize= int.MaxValue;
    
    foreach(SearchResult resEnt in objDirectoriesManager.FindAll())
    {
        string WorkstationName = resEnt.GetDirectoryEntry().Name;
        //Here you can add different type of check in order to filter out you results.
        objWorkstationNames.Add(ComputerName);
     }
        
     objDirectoriesManager.Dispose();
     objEntry.Dispose();
     //objWorkstationNames is the required list of Network Computer
     
    }
