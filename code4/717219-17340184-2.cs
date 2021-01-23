    public class TimeZone 
    {
        private List<Session> _ordered;
    
        public TimeSpan GmtOffset { get; set; }
        public List<Session> Session 
        { 
             get
             {
                 return this._ordered;
             }
    		 
    		 set
    		 {
    			if (value != null)
    			{
    				this._ordered = value.OrderBy(p => p.StartTime);		 
    			}
    		 }
        }
    }
