    using Outlook =Microsoft.Office.Interop.Outlook;
    
    private void kontaktImport_Click(object sender, RoutedEventArgs e)
            {
                Outlook.Application app = new Outlook.Application();
                Outlook.NameSpace NameSpace = app.GetNamespace("MAPI");
                Outlook.MAPIFolder ContactsFolder = NameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
                Outlook.Items ContactItems = ContactsFolder.Items;
                try
                {
                    foreach (Outlook.ContactItem item in ContactItems)
                    {
                        String output = "";
                        output = item.FirstName + "\n";
                        output += item.LastName;
                        TestTextBox.Text = output;
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    TestTextBox.Text = ex.ToString();
                }
            }         
