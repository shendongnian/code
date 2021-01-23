    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.Subject = "";
        mail.From = new MailAddress("");
        mail.Body = message;
        mail.To.Add(email);
        ////send the message
        System.Net.Mail.SmtpClient mySmtpClient = new System.Net.Mail.SmtpClient();
        System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("","");
        //mySmtpClient.Port="25";
        mySmtpClient.Host = "";
        mySmtpClient.UseDefaultCredentials = false;
        mySmtpClient.Credentials = myCredential;
        mySmtpClient.Send(mail);
   
    
    if (string.IsNullOrEmpty(email))
    {
        throw new Exception("You must supply an email address.");
    }
    if (string.IsNullOrEmpty(message))
    {
        throw new Exception("Please provide a message to send.");
    }
    // If we get this far we know that they entered enough data, so
    // here is where you would send the email or whatever you wanted
    // to do :)
