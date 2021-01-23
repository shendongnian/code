        public void MailKitSend(string senderEmail, string senderName, string subject, string bodyText, string receivers, string receiversCc)
        {
            // no receivers, no e-mail is sent
            if (string.IsNullOrEmpty(receivers))
                return;
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(Encoding.UTF8, senderName, senderEmail));
            msg.Subject = subject;
            var bb = new BodyBuilder {HtmlBody = bodyText};
            msg.Body = bb.ToMessageBody();
            IList<string> receiversEmails = receivers.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string receiver in receiversEmails)
                msg.To.Add(new MailboxAddress(Encoding.UTF8, "", receiver));
            if (!string.IsNullOrEmpty(receiversCc))
            {
                IList<string> receiversEmailsCc = receiversCc.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string receiverCc in receiversEmailsCc)
                    msg.Cc.Add(new MailboxAddress(Encoding.UTF8, "", receiverCc));
            }
            try
            {
                var sc = new MailKit.Net.Smtp.SmtpClient();
                if (!string.IsNullOrWhiteSpace(SmtpUser) && !string.IsNullOrWhiteSpace(SmtpPassword))
                {
                    sc.Connect(SmtpServer, 465);
                    sc.Authenticate(SmtpUser, SmtpPassword);
                }
                sc.Send(msg);
                sc.Disconnect(true);
            }
            catch (Exception exc)
            {
                string err = $"Error sending e-mail from {senderEmail} ({senderName}) to {receivers}: {exc}";
                throw new ApplicationException(err);
            }
        }
