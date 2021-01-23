    void Main()
    {
    	// Create an Outlook application.
    	Outlook._Application oApp;
    	oApp = new Outlook.Application();
    
    	// Create a new MailItem.
    	Outlook._MailItem oMsg;
    	oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem);
    	oMsg.Subject = "Send Attachment Using OOM in Visual Basic .NET";
    	oMsg.Body = "Hello World" + vbCr + vbCr;
    
    	// TODO: Replace with a valid e-mail address.
    	oMsg.To = "user@example.com";
    
    	// Add an attachment
    	// TODO: Replace with a valid attachment path.
    	string sSource = "C:\\Temp\\Hello.txt";
    	// TODO: Replace with attachment name
    	string sDisplayName = "Hello.txt";
    
    	string sBodyLen = oMsg.Body.Length;
    	Outlook.Attachments oAttachs = oMsg.Attachments;
    	Outlook.Attachment oAttach;
    	oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName);
    
    	// Send
    	oMsg.Send();
    
    	// Clean up
    	oApp = null;
    	oMsg = null;
    	oAttach = null;
    	oAttachs = null;
    }
