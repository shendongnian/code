    using System.Net;
    using System.Net.Mail;
     var fromAddress = new MailAddress("from@gmail.com", "From Name");
     var toAddress = new MailAddress("to@test.com", "To Name");
     const string fromPassword = "fromPass";
    const string subject = "Subject";
    const string body = "Body";
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
    
    
