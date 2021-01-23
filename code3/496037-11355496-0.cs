        public void SendEmailAsync(string id, string to, string from, string subject, string message, SendCompletedEventHandler callback)
        {
            // Command line argument must the the SMTP host.
            var client = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            if (bool.Parse(ConfigurationManager.AppSettings["PickupDirectoryFromIis"]))
            {
                client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            }
            // Specify the message content.
            var message = new MailMessage(from, to)
                              {
                                  Subject = subject,
                                  Body = message,
                                  BodyEncoding = Encoding.UTF8,
                                  SubjectEncoding = Encoding.UTF8
                              };
            client.SendCompleted += callback;
            try
            {
                client.SendAsync(message, id);
            }
            catch (SmtpException e)
            {
                this.EventLog.WriteEntry(e.ToString(), EventLogEntryType.Error);
            }
        }
