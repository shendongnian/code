    public class MailClient
        {
            public MailClient()
            {
                SmtpClient = new SmtpClient(MailConfiguration.Host)
                {
                    Port = MailConfiguration.Port,
                    Credentials = new NetworkCredential
                    {
                        UserName = MailConfiguration.UserName,
                        Password = MailConfiguration.Password
                    }
                };
            }
    
            public SmtpClient SmtpClient { get; }
        }
	
