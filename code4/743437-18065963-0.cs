    public static class DateTimeHelpers
    {
        private static int QuarterNumber( int month )
        {
            return (month-1) / 3 ;
        }
        public static void CurrentQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            start = new DateTime( instant.Year , 3*QuarterNumber(instant.Month) , 1 ) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
        public static void NextQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            CurrentQuarter( instant , out start , out end ) ;
            start = start.AddMonths(3) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
        public static void PreviousQuarter( this DateTime instant , out DateTime start , out DateTime end )
        {
            CurrentQuarter( instant , out start , out end ) ;
            start = start.AddMonths(-3) ;
            end   = start.AddMonths(3).AddTicks(-1) ;
            return ;
        }
    }
