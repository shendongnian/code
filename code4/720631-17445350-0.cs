    double DateTimeMIll = ConvertToTimestamp(DateTime.Today.Date);
    
    public static double ConvertToTimestamp(DateTime date)
    {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            double asd = (date - origin).Ticks;
            return asd;
    }
