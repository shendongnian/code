		public static Int64 GetDifferencesBetweenTwoDate(DateTime newDate, DateTime oldDate, string type)
        {
            var span = newDate - oldDate;
            switch (type)
            {
                case "tt": return (int)span.Ticks;
                case "ms": return (int)span.TotalMilliseconds;
                case "ss": return (int)span.TotalSeconds;
                case "mm": return (int)span.TotalMinutes;
                case "hh": return (int)span.TotalHours;
                case "dd": return (int)span.TotalDays;
            }
            return 0;
        }
