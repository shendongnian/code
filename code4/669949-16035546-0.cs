    System.Net.WebClient client = new System.Net.WebClient();
    string html = client.DownloadString("http://www.yoursite.com/email.htm");
    
    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.To.Add(toEmailAddress);
    message.Subject = "subject";
    message.From = new System.Net.Mail.MailAddress(from);
    message.Body = html;
    message.IsBodyHtml = true;
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("server");
    smtp.Send(message);
