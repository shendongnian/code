    public class MailController : MailerBase
    {
        public EmailResult VerificationEmail(User model)
        {
            To.Add(model.EmailAddress);
            From = "no-reply@mycoolsite.com";
            Subject = "Welcome to My Cool Site!";
            return Email("VerificationEmail", model);
        }
    }
    
