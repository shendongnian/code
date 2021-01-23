    public class MyCustomDate
    {
        private int _day;
        public int Year
        {
            get { return _day / 100; }
        }
        public Season Season
        {
            get { return (Season)(_day % 50); }
        }
        public int Day
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
            return string.Format("{0} {1}, {2}",
                Day, Season, Year);
        }
    }
