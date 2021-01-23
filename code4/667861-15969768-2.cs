    public class CompositeMail : Mail
    {
        private readonly List<Mail> _mails;
    
        public CompositeMail(params Mail[] mails) : this(mails.AsEnumerable())
        {
        }
    
        public CompositeMail(IEnumerable<Mail> mails)
        {
            if(mails == null) throw new ArgumentNullException("mails");
    
            _mails = mails.ToList();
        }
    
        public override string Subject
        {
            get { return string.Join("/", _mails.Select(x => x.Subject)); }
        }
    
        public override string Body
        {
            get
            {
                return string.Join(Environment.NewLine, _mails.Select(x => x.Body));
            }
        }
    }
