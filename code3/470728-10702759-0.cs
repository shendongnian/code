    using System.Web.Mail;
    MailMessage objMessage = new MailMessage();
    objMessage.From = "from";
    objMessage.To = "to";
    objMessage.Subject = "subject";
    objMessage.BodyFormat = MailFormat.Text;
    objMessage.Body = "body";
    SmtpMail.SmtpServer = "SmtpServer";
    SmtpMail.Send(objMessage);
