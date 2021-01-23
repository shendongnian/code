    public class EmailSender
    {
        private readonly ISmtpClientFactory factory;
        public EmailSender(ISmtpClientFactory factory)
        {
            this.factory = factory;
        }
        public void Send(MailMessage message)
        {
            using (var client = factory.Create())
            {
                using (message)
                {
                    client.Send(message);
                }
            }
        }
    }
    
    new EmailSender(new SmtpClientFactory()).Send(AdviceMessageFactory.Create(...));
 
