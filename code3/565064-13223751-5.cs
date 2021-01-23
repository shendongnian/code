    class Email
    {
           int UID { get; set; }
           DateTime Sent { get; set; }
           public string Body { get; set; }
    	   // put whichever properties you will need
    }
    
    List<Email> GetEmails(string mailbox);
    {
        Mailbox box = client.AllMailboxes[mailbox];
        Fetch fetch = box.Fetch;
            
    	List<Email> list = new List<Email>();
        for (int x = 1; x <= box.MessageCount; x++)
        {
            Message msg = fetch.MessageObject(x);
    		list.Add(new Email() { } // set properties from the msg object
        }
    	
    	return list;
    }
    
    void DeleteEmail(Email email, string mailbox)
    {
           Mailbox box = client.AllMailboxes[mailbox];
    	   box.UidDeleteMessage(email.Uid, true);
    }
    
    static void Main()
    {
    	List<Email> emails = GetEmails("inbox");
    	emails = emails.Where(email => email.Sent < DateTime.Now.AddHours(-hours))
    	foreach (Email email in emails)
    	     DeleteEmail(email);
    }
