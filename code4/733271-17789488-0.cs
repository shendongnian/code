        public static DateTime NearestDate(DateTime baseDateTime, List<string> acceptedDays)
        {
            DateTime result = new DateTime(baseDateTime.Year, baseDateTime.Month, baseDateTime.Day);
            List<DayOfWeek> acceptedDoW = new List<DayOfWeek>();
            acceptedDays.ForEach(x => acceptedDoW.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), x, true)));
            DayOfWeek currentDay = baseDateTime.DayOfWeek;
            int closestDay = int.MaxValue;
            acceptedDoW.ForEach(x =>
                {
                    int currentSpan = (int)x;
                    if (x < currentDay)
                        currentSpan += 7;
                    currentSpan = currentSpan - (int)currentDay;
                    if (currentSpan < closestDay)
                        closestDay = currentSpan;
                });
            return result.AddDays(closestDay);
        }
