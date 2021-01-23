    public class MailService : IMailService
    {
        public void SendReminderEmail(string to, string name)
        {
            var message = this.TemplatingService.GenerateReminderMessage(to, name);
            this.MailerService.SendEmail(to, message);
        }
    }
