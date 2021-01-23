    internal static string TimeSpanToDouble(TimeSpan timeSpan, string unit)
        {
            double result = 0;
            if (unit.Equals("MINUTES"))
                result = timeSpan.TotalMinutes;
            else if (unit.Equals("HOURS"))
                result = timeSpan.TotalHours;
            else if (unit.Equals("DAYS"))
                result = timeSpan.TotalHours / 24;
            else
                throw new Exception();
            return Convert.ToString(result);
        }
