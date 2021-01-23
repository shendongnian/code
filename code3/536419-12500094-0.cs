    Outlook.MAPIFolder fldContacts = (Outlook.MAPIFolder)OutlookApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts); 
    for (int i =1; i <aitem.Recipients.Count+1 ; i++) 
    { 
       Outlook.Recipient r = aitem.Recipients.Item(i); 
       if (!r.Resolved) r.Resolve(); 
       if (r.Resolved) 
       { 
         Outlook.ContactItem ci = (fldContacts.Items.Find("[Email1Address] = '" + r.Address + "'") as Outlook.ContactItem);
         if (ci != null) 
         { 
           //Now you got the contact deal with it here 
         } 
        }
    }
