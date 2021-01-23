    public class SendEmailTask : BackgroundTask
    {
        private const string MailServerIp = "yourip";
        public string[] To { get; set; }
        public string From { get; set; }
        public string Template { get; set; }
        public object ViewContext { get; set; }
        public string[] Attachments { get; set; }
        public string Subject { get; set; }
        public override void Execute()
        {
            MailMessage message = new MailMessage();
            try
            {
                MailAddress mailAddress = new MailAddress(From);
                message.From = mailAddress;
                
                foreach (string to in To) message.To.Add(to);
                message.Subject = Subject;
                if (Attachments.ReturnSuccess())
                {
                    foreach (string attachment in Attachments)
                        message.Attachments.Add(new Attachment(attachment));
                }
                message.Priority = MailPriority.High;
                message.Body = Template;
                message.AlternateViews
                       .Add(AlternateView
                       .CreateAlternateViewFromString(ViewContext.ToString(), new ContentType("text/html")));
                message.IsBodyHtml = true;
                new SmtpClient(MailServerIp)
                {
                    Port = 25,
                    UseDefaultCredentials = true
                }.Send(message);
            }
            catch (Exception e)
            {
                Logger.FatalException("Error sending email:", e);
            }
            finally
            {
                message.Dispose();
            }
        }
        public override string ToString()
        {
            return string.Format("To: {0}, From: {1}, Template: {2}, ViewContext: {3}, Attachments: {4}, Subject: {5}", To, From, Template, ViewContext, Attachments, Subject);
        }
    }
