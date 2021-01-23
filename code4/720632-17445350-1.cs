    long DateTimeMIll = ConvertToTimestamp(DateTime.Today.Date);
    
    public static long ConvertToTimestamp(DateTime date)
    {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long asd = (date - origin).Ticks;
            return asd;
    }
