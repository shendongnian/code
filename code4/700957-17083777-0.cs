      Microsoft.Office.Interop.Outlook.Items OutlookItems;
      Microsoft.Office.Interop.Outlook.Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();
      MAPIFolder Folder_Contacts;
      Folder_Contacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
      OutlookItems = Folder_Contacts.Items;
      MessageBox.Show("Wykryto kontaktów: " + OutlookItems.Count.ToString());
      
      for (int i = 0; i < OutlookItems.Count; i++)
      {
        Microsoft.Office.Interop.Outlook.ContactItem contact = (Microsoft.Office.Interop.Outlook.ContactItem)OutlookItems[i+1];
        sNazwa = contact.FullName;
        sFirma = contact.CompanyName;
        sAdress = contact.BusinessAddressStreet;
        sMiejscowosc = contact.BusinessAddressPostalCode + " " + contact.BusinessAddressCity;
        sEmail = contact.Email1Address;
        dataGridView1.Rows.Add(sNazwa, sFirma, sAdress, sMiejscowosc, sEmail);
        
      }
