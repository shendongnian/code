    public class CustomMailSender : SmtpMailSender
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        public CustomMailSender() { }
        public CustomMailSender(SmtpClient client) : base(client) { }
        public new void Send(MailMessage mail)
        {
            try
            {
                base.Send(mail);
				//Do some logging if you like
				_log.Info(....)
            }
            catch (SmtpException e)
            {
                //Do some logging 
                var message = mail.RawMessageString();
                _log.Error(message, e);
				// rethrow if you want...
            }
        }
        public new void SendAsync(MailMessage mail, Action<MailMessage> callback)
        {
            ... similar ...
        }
    }
