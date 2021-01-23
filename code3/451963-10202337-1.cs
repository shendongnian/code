    //Method with a class containing the info because informations are on several lines
    Contact[] contacts = MethodToRead("filename.txt"); 
    Contact[] filteredContacts = methodFilterContacts(contacts ); 
    foreach(Contact c in filteredContacts)
    {
         //Call your write method mentionned
         Writer.writer(c.name, c.lastname, c.number);
    }
    //Method if contact on only one line
    string[] contactLines = File.ReadAllLines("filename.txt"); 
    string[] filteredContactLines = methodFilterContacts(contactLines ); 
    //This will write everything as is
    File.WriteAllLines("filename.txt", filteredContactLines ); 
