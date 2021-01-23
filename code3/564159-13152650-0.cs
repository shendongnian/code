    public class SendMail
    {
    
        public SendMail(string SMTPServer, string fromEmail)
        {
            this.SMTPServer = SMTPServer;
            this.FromEmail = fromEmail;
        }
    
        public SendMail(string SMTPServer, string fromEmail, string Username, string Password) : this(SMTPServer, fromEmail)
        {
            this.Username = Username;
            this.Password = Password;
        }
    
        public string SMTPServer { get; set; }
        public string FromEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    
        public void Send(string toEmail, string subject, string data)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(toEmail);
    
            MailAddress mailAddress = new MailAddress(this.FromEmail);
    
            mailMsg.From = mailAddress;
    
            mailMsg.Subject = subject;
            mailMsg.Body = data;
            mailMsg.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient(this.SMTPServer, 25);
    
            if (this.Username.Length > 0 && this.Password.Length > 0)
            {
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(this.Username, this.Password);
                smtpClient.Credentials = credentials;
            }
    
            smtpClient.Send(mailMsg);
        }
    
    }
