    public static bool CompareDateAndHour(this DateTime one, DateTime two)
    {
        return (one.Date == two.Date &&
                one.Hour == two.Hour && 
                ...);
    }
