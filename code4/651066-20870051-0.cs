    public interface IMailer
    {
        void SendMail(string viewName, IEnumerable<string> to, string subject, IEnumerable<string> replayTo);
        void SendMail(string viewName, object model, IEnumerable<string> to, string subject,
            IEnumerable<string> replayTo);
        void SendMail(string viewName, IEnumerable<string> to, string from, string subject, IEnumerable<string> replayTo);
        void SendMail(string viewName, object model, IEnumerable<string> to, string from, string subject,
            IEnumerable<string> replayTo);
    }
    public class Mailer : MailerBase, IMailer
    {
        public void SendMail(string viewName, IEnumerable<string> to, string subject,
            IEnumerable<string> replayTo = null)
        {
            foreach (var email in to)
            {
                To.Add(email);
            }
            Subject = subject;
            if (replayTo != null)
                foreach (var email in replayTo)
                {
                    ReplyTo.Add(email);
                }
            Email(viewName).Deliver();
        }
        public void SendMail(string viewName, object model, IEnumerable<string> to, string subject,
            IEnumerable<string> replayTo = null)
        {
            foreach (var email in to)
            {
                To.Add(email);
            }
            Subject = subject;
            if (replayTo != null)
                foreach (var email in replayTo)
                {
                    ReplyTo.Add(email);
                }
            Email(viewName, model).Deliver();
        }
        public void SendMail(string viewName, IEnumerable<string> to, string from, string subject,
            IEnumerable<string> replayTo)
        {
            foreach (var email in to)
            {
                To.Add(email);
            }
            From = from;
            Subject = subject;
            if (replayTo != null)
                foreach (var email in replayTo)
                {
                    ReplyTo.Add(email);
                }
            Email(viewName).Deliver();
        }
        public void SendMail(string viewName, object model, IEnumerable<string> to, string from, string subject,
            IEnumerable<string> replayTo)
        {
            foreach (var email in to)
            {
                To.Add(email);
            }
            From = from;
            Subject = subject;
            if (replayTo != null)
                foreach (var email in replayTo)
                {
                    ReplyTo.Add(email);
                }
            Email(viewName, model).Deliver();
        }
    }
