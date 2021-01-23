    public static string FormatDate(this DateTime date, string format)
    {
        var builder = new StringBuilder();
        int numOfjs = 0;
        bool escaped = false;
        foreach (char c in format)
        {
            if (c == 'j' && !escaped)
            {
                numOfjs++;
            }
            else
            {
                if (c == 'j' && escaped)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                if (numOfjs > 0)
                {
                    var dayOfYearFormat = new string('0', Math.Min(3, numOfjs));
                    builder.Append(date.DayOfYear.ToString(dayOfYearFormat));
                }
                numOfjs = 0;
                builder.Append(c);
            }
            escaped = c == '\\' && !escaped;
        }
        if (numOfjs > 0)
        {
            var dayOfYearFormat = new string('0', Math.Min(3, numOfjs));
            builder.Append(date.DayOfYear.ToString(dayOfYearFormat));
        }
        return date.ToString(builder.ToString());
    }
