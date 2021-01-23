    public class MyCustomDate
    {
        private int _day;
        public int Year
        {
            get { return _day / 100; }
        }
        public Season Season
        {
            get { return (DayOfYear < 70) ? Season.Dry : Season.Rainy; }
        }
        public int DayOfYear
        {
            get { return _day % 100; }
        }
        // Create a date, given the year and the day within the year.
        public MyCustomDate(int year, int day)
        {
            _day = (100 * year) + day;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", DayOfYear, Season, Year);
        }
    }
