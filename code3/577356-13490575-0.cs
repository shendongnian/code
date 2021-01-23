    using System.Web.Mail
    public static bool SendErrorEmail(string to, string cc, string bcc, string subject,    string body, MailPriority priority, bool isHtml)
    {
     try
    {
    using (SmtpClient smtpClient = new SmtpClient())
    {
    using (MailMessage message = new MailMessage())
     {
     MailAddress fromAddress = new MailAddress(“yourmail@domain.com”, “Your name”);
     // You can specify the host name or ipaddress of your server
     smtpClient.Host = “mail.yourdomain.com”; //you can specify mail server IP address here
     //Default port is 25
     smtpClient.Port = 25;
     NetworkCredential info = new NetworkCredential(“yourmail@domain.com”, “your password”);
     smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
     smtpClient.UseDefaultCredentials = false;
     smtpClient.Credentials = info;
     //From address will be given as a MailAddress Object
     message.From = from;
     message.Priority = priority;
     // To address collection of MailAddress
     message.To.Add(to);
     message.Subject = subject;
     // CC and BCC optional
     if (cc.Length > 0)
     {
     message.CC.Add(cc);
     }
     if (bcc.Length > 0)
     {
     message.Bcc.Add(bcc);
     }
     //Body can be Html or text format;Specify true if it is html message
     message.IsBodyHtml = isHtml;
     // Message body content
     message.Body = body;
     // Send SMTP mail
     smtpClient.Send(message);
     }
     }
     return true;
     }
     catch (Exception ee)
     {
     Logger.LogError(ee, “Error while sending email to ” + toAddress);
     throw;
     }
    }
