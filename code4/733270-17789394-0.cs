      List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            DateTime sourceDate = DateTime.Now;
            DayOfWeek currentDay = sourceDate.DayOfWeek;
            int? smallestValue = null;
            foreach (DayOfWeek d in days)
            {
                int currentValue = (int)d - (int)currentDay;
                if (!smallestValue.HasValue)
                    smallestValue = currentValue;
                if(smallestValue > currentValue)
                    smallestValue = currentValue;
            }
            DateTime nearestDate = sourceDate.AddDays(smallestValue.Value);
