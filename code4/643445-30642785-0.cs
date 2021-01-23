    //Use the DirectoryEntry.InvokeSet method to invoke the AccountExpirationDate property setter.
    
    System.DirectoryServices.DirectoryEntry dirEntryLocalMachine =
        new System.DirectoryServices.DirectoryEntry("WinNT://" + Environment.MachineName + "/" + userID);
    
    dirEntryLocalMachine .InvokeSet("AccountExpirationDate", new object[] {new DateTime(2005, 12, 29)});
    
    //Commit the changes.
    usr.CommitChanges();
