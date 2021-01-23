    public static DateTime GiveMeADateTime(this string stringValue)
    {
    switch (stringValue)
    {
    case "today": return DateTime.Now;
    case "tomorrow": return DateTime.Now.AddDays(1);
    default: return DateTime.Now;
    }
    }
