     bool resolved;
            Microsoft.Office.Interop.Outlook.Application olApplication = new Microsoft.Office.Interop.Outlook.Application();
            // get nameSpace and logon.
            Microsoft.Office.Interop.Outlook.NameSpace olNameSpace = olApplication.GetNamespace("mapi");
            olNameSpace.Logon("Outlook", "", false, true);
            // get the Calender items
            Microsoft.Office.Interop.Outlook.MAPIFolder _olCalender = olNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
            // Get the Items (Appointments) collection from the Calendar folder.
            Microsoft.Office.Interop.Outlook.Items oItems = _olCalender.Items;
           
            foreach (object o in oItems)
            {
                
                if (o is Microsoft.Office.Interop.Outlook.AppointmentItem)
                {
                    Microsoft.Office.Interop.Outlook.Recipients recipients = ((Microsoft.Office.Interop.Outlook.AppointmentItem)o).Recipients;
                    foreach (Microsoft.Office.Interop.Outlook.Recipient rec in recipients)
                    {
                        resolved = rec.Resolve();
                        if (resolved)
                        {
                            Microsoft.Office.Interop.Outlook.ContactItem contactItem = rec.AddressEntry.GetContact();
                            MessageBox.Show(contactItem.CompanyName);
                        }
                    }
                   
                }
            }
