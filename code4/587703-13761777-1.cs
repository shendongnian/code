    public class MailTemplate
    {
        // regular auto properties
        public string MailFrom { get; set; }
        public string MailBody { get; set; }
        public MailTemplate ConfigureWith(Action<MailTemplate> func)
        {
            func(this);
            return this;
        }
    
        ...
    }
