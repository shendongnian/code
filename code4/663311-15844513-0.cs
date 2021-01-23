    public static class DateTimeExtensions
    {
    
    public static DateTime Yesterday (this DateTime x)
    {
    return x.AddDays(-1);
    }
    
    }
