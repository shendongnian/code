        public static DateTime AddWorkingDays(this DateTime date, int days)
        {
            if (days == 0)
                return date;
            int sign = days < 0 ? -1 : 1;
            while (days % 5 != 0 || !date.IsWorkingDay())
            {
                date = date.AddDays(sign);
                if (!date.IsWorkingDay())
                    continue;
                days -= sign;
            }
            int nWeekEnds = days / 5;
            DateTime result = date.AddDays(days + nWeekEnds * 2);
            return result;
        }
        public static bool IsWorkingDay(this DateTime date)
        {
            return !(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }
