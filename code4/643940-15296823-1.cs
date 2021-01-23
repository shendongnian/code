    public class MessageInformation {
        public string Subject { get; set; }
        public string str { get; set; }
        public MessageInformation(string subj, string str) {
            Subject = subj;
            this.str = str;
        }
    }
    ...
    select new MessageInformation(m.Subject, m.str)
