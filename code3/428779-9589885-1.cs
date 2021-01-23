    public class MyObject
    {
        public double Value { get; set; }
        public DateTime Time { get; set; }
        public DateTime GetStartOfPeriodByMins(int numMinutes)
        {
            int oldMinutes = Time.Minute;
            int newMinutes = (oldMinutes / numMinutes) * numMinutes;
            DateTime startOfPeriod = new DateTime(Time.Year, Time.Month, Time.Day, Time.Hour, newMinutes, 0);
            return startOfPeriod;
        }
    }
