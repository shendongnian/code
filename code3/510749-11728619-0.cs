    public class DTOffset:IConvertible
    {
        private DateTimeOffset DateTimeOffset;
        
        //Implementation of IConvertible
        public long ToInt64(IFormatProvider provider)
        {
            return DateTimeOffset.Ticks;
        }
        
        public DateTime ToDateTime(IFormatProvider provider)
        {
            DateTimeOffset.DateTime;
        }
        //and so on
        //wrapper properites of DateTimeOffset:
        public int DayOfYear{get{return DateTimeOffset.DayOfYear;}}
        
        public DateTime Date{get{return DateTimeOffset.Date;}}
        //and so on
    }
