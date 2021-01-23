    public class Person
    {
        public string EmailString { get; set; }
        [NotMapped]
        public MailAddress Email
        {
            get { return new MailAddress(this.EmailString); }
            set { this.EmailString = value.ToString(); }
        }
    }
