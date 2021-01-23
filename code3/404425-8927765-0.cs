    DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://DOM");
    //Create a searcher on your DirectoryEntry
    DirectorySearcher adSearch= new DirectorySearcher(directoryEntry);
    adSearch.SearchScope = SearchScope.Subtree;    //Look into all subtree during the search
    adSearch.Filter = "(&(ObjectClass=user)(sAMAccountName="+ username +"))";    //Filter information, here i'm looking at a user with given username
    SearchResult sResul = adSearch.FindOne();       //username is unique, so I want to find only one
    
    if (sResult.Properties.Contains("company"))     //Let's say I want the company name (any property here)
    {
        string companyName = sResult.Properties["company"][0].ToString();    //Get the property info
    }
