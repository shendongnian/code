        public static DateTime CalculateSLAFromNow(int minutes)
        {
            double days = (double)minutes / 540;
            DateTime now = DateTime.Now;
            DateTime later = now;
            while (days >= 1)
            {
                later = later.AddDays(1);
                if (later.DayOfWeek == DayOfWeek.Saturday)
                {
                    later = later.AddDays(2);
                }
                days--;
            }
            days = days * 540;
            later.AddMinutes(days);
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
