    static class  DateTimeExt {
        public static bool TimeOfDayIsBetween(this DateTime t, DateTime start, DateTime end) {
            var time_of_day = t.TimeOfDay;
            var start_time_of_day = start.TimeOfDay;
            var end_time_of_day = end.TimeOfDay;
            bool falls_within = start_time_of_day <= time_of_day && time_of_day <= end_time_of_day;
            if (start_time_of_day > end_time_of_day)
                falls_within = !falls_within;
            return falls_within;
        }
    }
    class Program {
        static void Test(DateTime t, DateTime start, DateTime end) {
            bool falls_within = t.TimeOfDayIsBetween(start, end);
            Console.WriteLine("{0} \t[{1},\t{2}]:\t{3}", t, start, end, falls_within);
        }
        static void Main(string[] args) {
            Test(new DateTime(2012, 1, 1, 0, 0, 0), new DateTime(2012, 1, 1, 7, 0, 0), new DateTime(2012, 1, 1, 19, 0, 0));
            Test(new DateTime(2012, 1, 1, 1, 0, 0), new DateTime(2012, 1, 1, 7, 0, 0), new DateTime(2012, 1, 1, 19, 0, 0));
            Test(new DateTime(2012, 1, 1, 0, 0, 0), new DateTime(2012, 1, 1, 19, 0, 0), new DateTime(2012, 1, 1, 21, 0, 0));
            Test(new DateTime(2012, 1, 1, 1, 0, 0), new DateTime(2012, 1, 1, 19, 0, 0), new DateTime(2012, 1, 1, 21, 0, 0));
            Test(new DateTime(2012, 1, 1, 0, 0, 0), new DateTime(2012, 1, 1, 21, 0, 0), new DateTime(2012, 1, 1, 7, 0, 0));
            Test(new DateTime(2012, 1, 1, 1, 0, 0), new DateTime(2012, 1, 1, 21, 0, 0), new DateTime(2012, 1, 1, 7, 0, 0));
            Test(new DateTime(2012, 05, 17, 00, 00, 00, 00), new DateTime(2012, 05, 17, 20, 00, 00), new DateTime(2012, 05, 18, 08, 00, 00));
        }
    }
