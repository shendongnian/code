    class Localization
    {
        public Localization(string timeZoneId = "UTC")
        {
            TimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
        public virtual TimeZoneInfo TimeZone { get; set; }
        public DateTime Now
        {
            get
            {
                return     TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZone)
            }
        }
    }
