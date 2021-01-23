    public partial class JeroensCustomClass
    {
        public string ZNGU_T { get; set; } // Time
        public string ZNGU_D { get; set; } // Date
        
        public DateTime DeliveryDateTimeFrom
        {
            get
            {
                var date = DateTime.ParseExact(ZNGU_D, "yyyyMMdd", CultureInfo.InvariantCulture);
                var time = DateTime.ParseExact(ZNGU_D, "yyyyMMdd", CultureInfo.InvariantCulture);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            }
            set
            {
                ZNGU_D = value.ToString("yyyyMMdd");
                ZNGU_T = value.ToString("HHmmss");
            }
        }
    }
