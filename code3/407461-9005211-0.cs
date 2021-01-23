        public static DateTime CalculateSLAFromNow(int minutes)
        {
            DateTime now = DateTime.Now;
            DateTime later = now.AddMinutes(minutes);
            if (later.Hour > 17)
            {
                later = later.AddHours(15);
            }
            if (later.DayOfWeek == DayOfWeek.Saturday)
            {
                later = later.AddDays(2);
            }
            else if(later.DayOfWeek == DayOfWeek.Sunday)
            {
                later = later.AddDays(1);
            }
            return later;
        }
    }
