      using System.Collections.Generic; 
    // ... 
    private List<Outlook.ContactItem> GetListOfContacts(Outlook._Application OutlookApp) 
        { 
        List<Outlook.ContactItem> contItemLst = null; 
        Outlook.Items folderItems =null; 
        Outlook.MAPIFolder mapiFoldSuggestedConts = null; 
        Outlook.NameSpace nameSpc = null; 
        Outlook.MAPIFolder mapiFoldrConts = null; 
        object itemObj = null; 
        try 
        { 
            contItemLst = new List<Outlook.ContactItem>(); 
            nameSpc = OutlookApp.GetNamespace("MAPI"); 
            // getting items from the Contacts folder in Outlook 
            mapiFoldrConts = 
                 nameSpc.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts); 
            folderItems = mapiFoldrConts.Items; 
            for (int i = 1; folderItems.Count >= i; i++) 
            { 
                itemObj = folderItems[i]; 
                if (itemObj is Outlook.ContactItem) 
                    contItemLst.Add(itemObj as Outlook.ContactItem); 
                else 
                    Marshal.ReleaseComObject(itemObj); 
            } 
            Marshal.ReleaseComObject(folderItems); 
            folderItems = null; 
            // getting items from the Suggested Contacts folder in Outlook 
            mapiFoldSuggestedConts = nameSpc.GetDefaultFolder( 
                 Outlook.OlDefaultFolders.olFolderSuggestedContacts); 
            folderItems = mapiFoldSuggestedConts.Items; 
            for (int i = 1; folderItems.Count >= i; i++) 
            { 
                itemObj = folderItems[i]; 
                if (itemObj is Outlook.ContactItem) 
                    contItemLst.Add(itemObj as Outlook.ContactItem); 
                else 
                    Marshal.ReleaseComObject(itemObj); 
            } 
        } 
        catch (Exception ex) 
        { 
            System.Windows.Forms.MessageBox.Show(ex.Message); 
        } 
        finally 
        { 
            if (folderItems != null) 
                Marshal.ReleaseComObject(folderItems); 
            if (mapiFoldrConts != null) 
                Marshal.ReleaseComObject(mapiFoldrConts); 
            if (mapiFoldSuggestedConts != null) 
                Marshal.ReleaseComObject(mapiFoldSuggestedConts); 
            if (nameSpc != null) Marshal.ReleaseComObject(nameSpc); 
        } 
        return contItemLst; 
    } 
