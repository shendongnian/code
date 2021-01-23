    class CalendarSealesHelper
    {
       public CalendarDate {get; set;}
       public NextDayDateTime {get; set;}
    }
    
    class CalendarSealesHelperComparer : IEqualityComparer<CalendarSealesHelper>
    {
        public bool Equals(CalendarSealesHelper c1, CalendarSealesHelper c2)
        {
            if (c2.CalendarDate >= c1.CalendarDate 
                   && c2.NextDayDateTime < c1.NextDayDateTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
        public int GetHashCode(CalendarSealesHelper c)
        {
            int hCode = (int)c.CalendarDate.Ticks ^ (int)c.NextDayDateTime.Ticks;
            return hCode.GetHashCode();
        }
    }
