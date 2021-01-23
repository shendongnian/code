        public int WholeMonths
        {
            get
            {
                var startInEndsYear = Start.AddYears(End.Year - Start.Year);
                // Are within a month of each other if EITHER:
                // 1. Month is the same
                // 2. Month period is within 1 
                //    AND
                //    The difference between days of the year is less than the number of days in the start's month
                var sameMonth = End.Month == startInEndsYear.Month || (End.Month - 1 == Start.Month && (End.DayOfYear - startInEndsYear.DayOfYear) / (double)DateTime.DaysInMonth(startInEndsYear.Year, startInEndsYear.Month) < 1.0d );
                var sameMonthAndDay = sameMonth && End.Day == Start.Day;
                
                var res = (End.Year - Start.Year) * 12;
                if (sameMonth && !sameMonthAndDay)
                {
                    res -= (startInEndsYear > End) ? 1 : 0;
                }
                else if (sameMonthAndDay)
                {
                    res -= (End.TimeOfDay < Start.TimeOfDay ? 1 : 0);
                }
                else
                {
                    res -= Start.Month;
                    res += End.Month;
                }
                return res;
            }
        }
