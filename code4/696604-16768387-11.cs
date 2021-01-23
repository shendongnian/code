    public class Meter
    {
        public int id;
        public List<Reading> readings;
        public Reading FirstReading 
        {
            get
            {
                return readings.OrderBy(r => r.time).First();
            }
        }
        public Reading LastReading
        {
            get
            {
                return readings.OrderBy(r => r.time).Last();
            }
        }
    }
