        public bool IsWeekend(DateTime dateToCheck)
        {
            DayOfWeek day = (DayOfWeek) dateToCheck.Day;
            return ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday)); 
        }
