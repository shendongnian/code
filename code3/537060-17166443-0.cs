                DataTable dt = new DataTable();
                dt.Columns.Add("FirstName");
                dt.Columns.Add("MiddleName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Email");
    
                Microsoft.Office.Interop.Outlook.Items OutlookItems;
                Microsoft.Office.Interop.Outlook.Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();
                MAPIFolder Folder_Contacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                OutlookItems = Folder_Contacts.Items;
    
                foreach (var item in OutlookItems)
                {
                    var contact = item as ContactItem;
                    if (contact != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr["FirstName"] = contact.FirstName;
                        dr["MiddleName"] = contact.MiddleName;
                        dr["LastName"] = contact.LastName;
                        dr["Email"] = contact.Email1Address;
                        dt.Rows.Add(dr);
                    }
                }
