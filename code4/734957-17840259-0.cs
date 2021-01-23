    Imaps imap = new Imaps();
    imap.OnSSLServerAuthentication += new Imaps.OnSSLServerAuthenticationHandler(delegate(object sender, ImapsSSLServerAuthenticationEventArgs e)
    {
      //Since this is a test, just accept any certificate presented.
      e.Accept = true;
    });
    imap.MailServer = "your.mailserver.com";
    imap.User = "user";
    imap.Password = "password";
    imap.Connect();
    imap.Mailbox = "INBOX";
    imap.SelectMailbox();
    imap.MessageSet = "X"; //Replace "X" with the message number/id for which you wish to retrieve attachments.
    imap.FetchMessageInfo();
    for (int i = 0; i < imap.MessageParts.Count; i++)
    {
      if (imap.MessageParts[i].Filename != "")
      {
        //The MessagePart Filename is not an empty-string so this is an attachment
   
        //Set LocalFile to the destination, in this case we are saving the attachment
        //in the C:\Test folder with its original filename.
        //Note: If LocalFile is set to an empty-string the attachment will be available
        //      through the MessageText property.
        imap.LocalFile = "C:\\Test\\" + imap.MessageParts[i].Filename;
        
        //Retrieve the actual attachment and save it to the location specified in LocalFile.
        imap.FetchMessagePart(imap.MessageParts[i].Id);
      }
    }
    imap.Disconnect();
