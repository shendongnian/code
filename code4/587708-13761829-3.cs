    public class MailTemplateBuilder
    {
        string _body;
        string _subject;
        string _sender;
        public MailTemplateBuilder WithBody(string body)
        {
            _body = body;
            return this;
        }
        public MailTemplateBuilder WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }
        public MailTemplateBuilder WithSender(string sender)
        {
            _sender = sender;
            return this;
        }
        public MailTemplate Build()
        {
            return new MailTemplate(_sender, _subject, _body);
        }
    }
