    ImapX.ImapClient client = null;
    client = new ImapX.ImapClient("imap.gmail.com", 993, true);
    if (!client.Connection())
    {
        MessageBox.Show("Couldn't connect to gmail. Check your internet connection and try again");
        client = null;
        return false;
     }
     if (!client.LogIn(email, password))
     {
         MessageBox.Show("Email And/Or password incorrect");
         client = null;
         return false;
     }
