    public class ComplexClass
    {
        private readonly Lazy<DateTime> _date;
    
        public DateTime Date
        {
            get
            {
                return _date.Value;
            }
        }
    
        public ComplexClass(Lazy<DateTime> date)
        {
            // Allow your DI framework to determine where dates come from.
            // This separates the concern of date resolution from this class,
            // whose responsibility is mostly around determining information
            // based on this date.
            _date = date;
        }
        public string GetDay()
        {
            if (Date.Day == 1 && Date.Month == 1)
            {
                return "New year!";
            }
            return string.Empty;
        }
    }
