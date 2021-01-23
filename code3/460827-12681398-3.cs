    using System.Net.Mail;
    using System.Net;
    private void SendMail( string targetMail, 
                           string shownTargetName, 
                           string[] attachmentNames) {
      var fromAddress = new MailAddress("support@infinibrain.net", "MailSendingProgram");
      var toAddress = new MailAddress(targetMail, shownTargetName);
      const string fromPassword = "12345isAbadPassword";
      subject = "Your Subject";
      body = 
            @"
              Here
              you can put in any text
              that will appear in the body
            ";
      var smtp = new SmtpClient {
        Host = "smtp.mailserver.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
      };
      using (var message = new MailMessage(fromAddress, toAddress) {
                                 Subject = subject,
                                 Body = body }
            ) {
        foreach(string filePath in attachmentNames[]) {
          Attachment attachMail = new Attachment(filePath);
          message.Attachments.Add(attachMail);
        }
        try {
          smtp.Send(message);
          MessageBox.Show("E-Mail sent!");
        } catch {
          MessageBox.Show("Sending failed, check your internet connection!");
        }
      }
    }
