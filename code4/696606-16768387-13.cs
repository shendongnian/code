    public class Meter
    {
        public int id;
        public List<Reading> readings;
        public Reading GetFirstReading(DateTime begin, DateTime end)
        {
            var filteredReadings = readings.Where(r => r.time >= begin && r.time <= end);
            if(!HasReadings(begin, end))
            {
                throw new ArgumentOutOfRangeException("No readings available during this period");
            }
            return filteredReadings.OrderBy(r => r.time).First();
        }
        public Reading GetLastReading(DateTime begin, DateTime end)
        {
            var filteredReadings = readings.Where(r => r.time >= begin && r.time <= end);
            if(!HasReadings(begin, end))
            {
                throw new ArgumentOutOfRangeException("No readings available during this period");
            }
            return filteredReadings.OrderBy(r => r.time).Last();
        }
        public bool HasReadings(DateTime begin, DateTime end)
        {
            return readings.Any(r => r.time >= begin && r.time <= end);
        }
    }
