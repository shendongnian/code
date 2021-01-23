    public sealed class MyCalendarDrawer
    {
        private readonly Func<DateTime, string> _dateFormatter;
        public MyCalendarDrawer(Func<DateTime, string> dateFormatter)
        {
            _dateFormatter = dateFormatter;
        }
        public void Draw()
        {
            // Do some work that involves displaying dates...
            DateTime date = DateTime.Now;
            string dateString = _dateFormatter(date);
            // Display dateString somehow.
        }
    }
