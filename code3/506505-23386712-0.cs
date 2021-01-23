    //Create message
    SendGrid myMessage = SendGrid.GetInstance();
    myMessage.AddTo("anna@example.com");
    myMessage.From = new MailAddress("john@example.com", "John Smith");
    myMessage.Subject = "Testing the SendGrid Library";
    myMessage.Text = "Hello World!";
    
    // Add attachment
    myMessage.AddAttachment(@"C:\file1.txt");
    
    //Set up the transport
    var credentials = new NetworkCredential("username", "password");
    var transportWeb = Web.GetInstance(credentials);
    
    // Send the email.
    transportWeb.Deliver(myMessage);
