        public static List<DateTime> GetAffectedHours(DateTime start, DateTime end)
        {
            List<DateTime> result = new List<DateTime>();
            
            // Strip start of its minutes/seconds/etc
            DateTime initial = new DateTime(start.Year, start.Month, start.Day, start.Hour, 0, 0);
            // Go ahead and get the next hour
            DateTime iterator = initial.AddHours(1.0);
            
            // if it is still before the end
            while (iterator < end)
            {
                // add it to the results list
                result.Add(iterator);
                
                // and get the next hour
                iterator = iterator.AddHours(1.0);
            }
            return result;
        }
