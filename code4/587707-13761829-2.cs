    public static class MailTemplateBuilder
    {
        public static MailTemplate WithBody(this MailTemplate item, string body)
        {
            item.MailBody = body;
            return item;
        }
        public static MailTemplate WithSubject(this MailTemplate item, string subject)
        {
            item.MailSubject = subject;
            return item;
        }
        public static MailTemplate WithSender(this MailTemplate item, string sender)
        {
            item.MailFrom = sender;
            return item;
        }
    }
