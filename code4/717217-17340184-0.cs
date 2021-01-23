    public class TimeZone {
        public TimeSpan GmtOffset { get; set; }
        public List<Session> Session { get; set; }
        public List<Session> OrderedSession 
        { 
           get{ return this.Session.OrderBy(p=> p.StartTime);}
        }
    }
