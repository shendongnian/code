    using System.Net;
    using System.Net.Mail;
    
    var fromAddress = new MailAddress("from@gmail.com", "From Name"); //Both the email addresses would be yours
    var toAddress = new MailAddress("to@example.com", "To Name"); //Both the email addresses would be yours
    const string fromPassword = "fromPassword";
    const string subject = "There name or whatever";
    const string body = "Errors ect....";
    
    var smtp = new SmtpClient
               {
                   Host = "smtp.gmail.com",
                   Port = 587,
                   EnableSsl = true,
                   DeliveryMethod = SmtpDeliveryMethod.Network,
                   UseDefaultCredentials = false,
                   Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
               };
    using (var message = new MailMessage(fromAddress, toAddress)
                         {
                             Subject = subject,
                             Body = body
                         })
    {
        smtp.Send(message);
    }
