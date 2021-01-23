    //declare Outlook application             
    _Application objOutlook = new Outlook.Application();  //create it
    _NameSpace objNs = objOutlook.Session; //create new session
                
    MAPIFolder oPublicFolders = objNs.Folders["Public Folders"];
    MAPIFolder oAllPublicFolders = oPublicFolders.Folders["All Public Folders"];
    foreach (MailItem item in itms)
    {
         GetNewMailItem(objOutlook, objContacts, item);
    }
    
    Marshal.ReleaseComObject(objOutlook); //release outlook com object
