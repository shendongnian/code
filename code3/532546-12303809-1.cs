    public class SendWelcomeEmailComposer
    {
        MailMessage Compose(User user)
    }
    public class EmailSender
    {
        void SendEmail(MailMessage);
    }
    public class EmailService
    {
        void SendWelcomeEmail(User user)
        {
            // compose email
            // and send using the classes above.
        }
    }
