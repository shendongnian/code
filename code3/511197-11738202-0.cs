    public interface IEmailService
    {
        bool SendEmail();
        // etc...
    }
    public class EmailService : IEmailService
    {
        //...
    }
