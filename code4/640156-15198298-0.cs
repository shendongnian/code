    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.Subject = "Title";
    message.From = new System.Net.Mail.MailAddress(yourEmailExpeditor);
    message.Body = "content message here";
    
    //Initialize the smtp
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(adress,int.Parse(port));
    //Send the message
    smtp.Send(message);
