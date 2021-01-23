    public static bool IsDayTime(this DateTime date)
    {
        TimeSpan timeOfDay = date.TimeOfDay;
        return 8 < timeOfDay.Hours && timeOfDay.Hours < 16;
    }
