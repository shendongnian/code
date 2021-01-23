    [Flags]
    public enum DayOfWeek
    {
       Undefined = 0,
       Mon = 1,
       Tue = 2,
       Wed = 4,
       Thu = 8,
       Fri = 16,
       Sat = 32,
       Sun = 64
    }
    
    DayOfWeek bitmask = DayOfWeek.Mon | DayOfWeek.Wed | DayOfWeek.Sat;
