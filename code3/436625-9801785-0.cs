    var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
    client.EnableSsl = true;
    client.UseDefaultCredentials = false;
    client.Credentials = new System.Net.NetworkCredential("me@gmail.com", "xxxxxxx");
    
    try
    {
    	// Create instance of message
    	System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    
    	// Add receiver
    	message.To.Add("me@gmail.com");
    
    	// Set sender
    	// In this case the same as the username
    	message.From = new System.Net.Mail.MailAddress("me@gmail.com");
    
    	// Set subject
    	message.Subject = "Test";
    
    	// Set body of message
    	message.Body = "En test besked";
    
    	// Send the message
    	client.Send(message);
    
    	// Clean up
    	message = null;
    }
    catch (Exception e)
    {
    	Console.WriteLine("Could not send e-mail. Exception caught: " + e);
    }
