    using DotRas;
    RasPhoneBook pbk = new RasPhoneBook();
    pbk.Open(@"C:\PathToYourPhoneBook.pbk");
    // NOTE: You can also use RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers) to 
    // access the path as defined by the Windows SDK rather than having to hard-code it.
    
    foreach (RasEntry entry in pbk.Entries)
    {
        // Do something useful.
    }
