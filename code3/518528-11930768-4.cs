        public static IEnumerable<Tuple<string, int>> MonthsBetween(DateTime startDate,DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;
            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year);                
                iterator = iterator.AddMonths(1);
            }
        }
