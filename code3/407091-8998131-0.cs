    [Export("SmtpEmailService", typeof(IEmailService))]
    public class SmtpEmailService : IEmailService {
    }
    
    [Export("AmazonEmailService", typeof(IEmailService))]
    public class AmazonEmailService : IEmailService {
    }
    
    [Import("AmazonEmailService")]
    public IEmailService EmailService { get; set; }
