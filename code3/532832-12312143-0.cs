        private void SendEmailToAdmin(string message)
        {
            SmtpSection smtpSection = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
            string host = smtpSection.Network.Host;
            if (string.IsNullOrEmpty(host))
            {
                host = "127.0.0.1";
            }
            using (SmtpClient smtpClient = new SmtpClient(host, smtpSection.Network.Port))
            {
                MailMessage mail = new MailMessage(smtpSection.From, Properties.Settings.Default.SupportEmailAddress);
                mail.Subject = Environment.MachineName + ": Error";
                mail.IsBodyHtml = false;
                mail.Body = message;
                smtpClient.Send(mail);
            }
        }
