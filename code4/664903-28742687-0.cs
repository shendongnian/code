    bool HasExplicitTime(DateTime parsedTimestamp, string str_timestamp)
    {
        string[] dateTimeSeparators = { "T", " ", "@" };
        string[] timeSeparators = {
            CultureInfo.CurrentUICulture.DateTimeFormat.TimeSeparator,
			CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator,
            ":"};
        if (parsedTimestamp.TimeOfTheDay.TotalSeconds != 0)
            return true;
        string dateOrTimeParts[] = str_timestamp.Split(
                dateTimeSeparators,
                StringSplitOptions.RemoveEmptyEntries);
        bool hasTimePart = dateOrTimeParts.Any(part =>
                part.Split(
                        timeSeparators,
                        StringSplitOptions.RemoveEmptyEntries).Length > 1);
        return hasTimePart;
    }
