    public static class DateTimeHelpers
    {
        private static DateTime StartDateOfCurrentQuarter( DateTime instant )
        {
            return new DateTime( instant.Year , 3*((instant.Month-1)/3) , 1 ) ;
        }
        public static void CurrentQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            start = StartDateOfCurrentQuarter(instant) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
        public static void NextQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            start = StartDateOfCurrentQuarter(instant).AddMonths(3) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
        public static void PrevQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            start = StartDateOfCurrentQuarter(instant).AddMonths(-3) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
    }
