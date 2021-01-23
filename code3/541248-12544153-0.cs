        /// <summary>
        /// Sends mail with authentification
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHTMLbody"></param>
        /// <param name="SMTPhost"></param>
        /// <param name="priority"></param>
        /// <param name="credentials"></param>
        /// <param name="port"></param>
        /// <param name="enableSsl"></param>
        public static void SendMailWithAuthentication(List<string> recipients, string from, string subject, string body, bool isHTMLbody,
            string SMTPhost, System.Net.Mail.MailPriority priority, System.Net.NetworkCredential credentials, int? port, bool enableSsl)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            foreach (string recipient in recipients)
            {
                message.To.Add(recipient);
            }
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress(from);
            message.IsBodyHtml = isHTMLbody;
            message.Body = body;
            message.Priority = priority;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = credentials;
            client.Host = SMTPhost;
            if (port != null)
            {
                client.Port = (int)port;
            }
            client.EnableSsl = enableSsl;
            client.Send(message);
            message.Dispose();
        }
