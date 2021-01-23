        public static DateTime AddWorkingDays(DateTime startDate, int amount)
        {
            // It really is that simple!
            if (amount <= 0)
                return startDate;
            var ret = startDate;
            for (int i = 0; i < amount; )
            {
                var nextDay = ret.AddDays(1);
                // If it's saturday or sunday, just add it, but don't increment i. That way we'll
                // just keep going and virtually "skipping" the weekends.
                if (nextDay.DayOfWeek == DayOfWeek.Saturday || nextDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    ret = ret.AddDays(1);
                    continue;
                }
                ret = ret.AddDays(1);
                i++;
            }
            return ret;
        }
