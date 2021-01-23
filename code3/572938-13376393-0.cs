    SmtpClient clientesmtp = GetSmtpClient();
    MailMessage msg = new MailMessage("from@gmail.com", "to@gmail.com", "Subject","body");
    msg.IsBodyHtml = true;
    clientesmtp.Send(msg);           
      
    private static SmtpClient GetSmtpClient()
    {
    SmtpClient clientesmtp = new SmtpClient("smtp.gmail.com", 587);
    clientesmtp.Credentials = new System.Net.NetworkCredential("user", "password");
    clientesmtp.EnableSsl = true;
    return clientesmtp;
    }
