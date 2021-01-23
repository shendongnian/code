        public Outlook.MAPIFolder sentFolder = null;
        public Outlook.Items itmsSentFolder = null;
        sentFolder = applicationObject.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
        itmsSentFolder = sentFolder.Items;
        itmsSentFolder.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(itmsSentFolder_ItemAdd); 
    void itmsSentFolder_ItemAdd(object Item)
            {
               
                    if (Item is Outlook.MailItem)
                    {
                        Outlook.MailItem mailItem = Item as Outlook.MailItem;
                        if (mailItem != null)
                        {
                            MessageBox.Show("Sender's Email Address " + mailItem.SenderEmailAddress);
                            MessageBox.Show("Sent On Behalf Of Name " + mailItem.SentOnBehalfOfName);
                            Outlook.Account ac = (Outlook.Account)mailItem.SendUsingAccount;
                            if(ac != null)
                            {
                                MessageBox.Show("Sender's Account Name " + ac.SmtpAddress);
                            }
                            
                        }
                    
                }
            }
