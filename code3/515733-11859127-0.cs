    public class DisplayDateTime
    {
        private DateTime dt;
        private string shortDate;
        public DisplayDateTime(DateTime d)
        {
            dt = d;
            shortDate = dt.ToString("d");
        }
        public DateTime Date
        {
            get
            {
                return dt;
            }
        }
        public string ShortDate
        {
            get
            {
                return shortDate;
            } 
        
        }
    }
