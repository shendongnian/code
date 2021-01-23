    public class Email
    {
        NetworkCredential credentials;
        MailAddress sender;
    
        public Email(NetworkCredential credentials, MailAddress sender)
        {
            this.credentials = credentials;
            this.sender = sender;
        }
    
        public bool EnableSsl
        {
            get { return _EnableSsl; }
            set { _EnableSsl = value; }
        }
        bool _EnableSsl = true;
    
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }
        string _Host = "smtp.gmail.com";
    
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        int _Port = 587;
    
        public void Send(MailAddress recipient, string subject, string body, Action<MailMessage> action, params FileInfo[] attachments)
        {
            SmtpClient smtpClient = new SmtpClient();
    
            // setup up the host, increase the timeout to 5 minutes
            smtpClient.Host = Host;
            smtpClient.Port = Port;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = credentials;
            smtpClient.Timeout = (60 * 5 * 1000);
            smtpClient.EnableSsl = EnableSsl;
    
            using (var message = new MailMessage(sender, recipient)
            {
                Subject = subject,
                Body = body
            })
            {
                foreach (var file in attachments)
                    if (file.Exists)
                        message.Attachments.Add(new Attachment(file.FullName));
                if(null != action)
                    action(message);
                smtpClient.Send(message);
            }
        }
    }
