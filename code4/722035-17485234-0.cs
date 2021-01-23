        // Get the Nth day of the month
        private static DateTime NthOf(DateTime CurDate, int Occurrence, DayOfWeek Day)
        {
            var fday = new DateTime(CurDate.Year, CurDate.Month, 1);
            if (Occurrence == 1)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (fday.DayOfWeek == Day)
                    {
                        return fday;
                    }
                    else
                    {
                        fday = fday.AddDays(1);
                    }
                }
                return fday;
            }
            else
            {
                var fOc = fday.DayOfWeek == Day ? fday : fday.AddDays(Day - fday.DayOfWeek);
                if (fOc.Month < CurDate.Month) Occurrence = Occurrence + 1;
                return fOc.AddDays(7 * (Occurrence - 1));
            }
        }
