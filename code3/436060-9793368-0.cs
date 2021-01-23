    public class SessionWrapper
    {
        private HttpSessionBase Session { get; set; }
        public SessionWrapper( HttpSessionBase session )
        {
            Session = session;
        }
        public SessionWrapper() : this( HttpContext.Current.Session ) { }
        public string Key
        {
             get { return Session["key"] as string ?? "none";
        }
        public int MaxAllowed
        {
             get { return Session["maxAllowed"] as int? ?? 10 }
        }
    }
