        using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("ares"))
        {
           using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
           {
              msg.From = new MailAddress("system@lol.dk");
              msg.To.Add(new MailAddress("lmy@lol.dk"));
              msg.Subject = "IBM PUDO";
              msg.Body = sentFiles.Count() + " attached file(s) has been sent to the customer(s) in question ";
              msg.IsBodyHtml = true;
              foreach (string file in sentFiles)
              {
                  Attachment attachment = new Attachment(file);
                  msg.Attachments.Add(attachment);
              }
              client.Send(msg);
            }
         }
