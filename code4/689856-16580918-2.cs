    private void FormRegionMessageClassArchivadoFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
                {
                    
                    Outlook.MailItem item = (Outlook.MailItem)e.OutlookItem;     
                     if (item.Attachments.Count > 0)
                     {
                                    int attachRestantes = item.Attachments.Count;
                                    for (int j = attachRestantes; j >=1; j--)
                                    {
                                        //get attachments
                                    }           
    
                     }     
                }
