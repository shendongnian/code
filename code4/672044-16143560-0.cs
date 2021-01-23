                    // get active Window
                object activeWindow = Globals.ThisAddIn.Application.ActiveWindow();
                if (activeWindow is Microsoft.Office.Interop.Outlook.Explorer)
                {
                    // its an explorer window
                    Outlook.Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
                    Outlook.Selection selection = explorer.Selection;
                    for (int i = 0; i < selection.Count; i++)
                    {
                        if (selection[i + 1] is Outlook.MailItem)
                        {
                            Outlook.MailItem mailItem = selection[i + 1] as Outlook.MailItem;
                            CreateFormOrForm(mailItem);
                        }
                        else
                        {
                            Logging.Logging.Log.Debug("One or more of the selected items are not of type mail message..!");
                            System.Windows.Forms.MessageBox.Show("One or more of the selected items are not of type mail message..");
                        }
                    }
                }
                if (activeWindow is Microsoft.Office.Interop.Outlook.Inspector)
                {
                    // its an inspector window
                    Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
                    Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;
                    CreateFormOrForm(mailItem);
                }
