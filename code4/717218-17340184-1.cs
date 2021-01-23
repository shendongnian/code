    public class TimeZone 
    {
        private List<Session> _ordered;
    
        public TimeSpan GmtOffset { get; set; }
        public List<Session> Session { get; set; }
        public List<Session> OrderedSession 
        { 
             get
             {
                 if (this._ordered == null && this.Session != null)
                 {	   
                     this._ordered = this.Session.OrderBy(p=> p.StartTime);
                 }
    
                 return this._ordered;
             }
        }
    }
