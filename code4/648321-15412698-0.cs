        List<DateTime> GetDateRange(List<LockedDate> source, DateTime start, DateTime end)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (LockedDate lockedDate in source)
            {
                if (!lockedDate.IsYearly && (lockedDate.Date >= start && lockedDate.Date <= end))
                {
                    result.Add(lockedDate.Date);
                }
                else if (lockedDate.IsYearly && (lockedDate.Date >= start && lockedDate.Date <= end))
                {
                    DateTime date = new DateTime(start.Year, lockedDate.Date.Month, lockedDate.Date.Day);
                    do
                    {
                        result.Add(date);
                        date = date.AddYears(1);
                    } while (date <= end);
                }
            }
            return result;
        }
