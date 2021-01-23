    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Net.Configuration;
     MailMessage message = new MailMessage(FromMailId, ToMaiId, "YourMessage");
     SmtpClient emailClient = new SmtpClient(mailsmtp.Trim());
     System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(FromMailId,                                          
     FromMailIdpwd);
     emailClient.UseDefaultCredentials = false;
     emailClient.Credentials = SMTPUserInfo;
      emailClient.Send(message);
