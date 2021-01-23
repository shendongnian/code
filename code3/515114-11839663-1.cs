            var emailFrom = new MailAddress(sender);
            var emailTo = new MailAddress(recipient);
            var mailMessage = new MailMessage(emailFrom, emailTo)
            {
                Subject = "Subject ",
                Body = "Body"
            };
            using (var client = new SmtpClientAdapter())
            {
                return client.Send(mailMessage);
            }
