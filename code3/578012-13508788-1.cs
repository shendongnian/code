            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress("recipient@somedomain.com", "Recipient Display Name"));
            mailMessage.Subject = "Some Subject";
            mailMessage.Body = "One gorgeous body";
            smtp.Send(mailMessage);
