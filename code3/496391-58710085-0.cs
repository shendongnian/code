    public static DateTime UpToNearestXmin( DateTime dt, int block )
    {
       int a = dt.Minute;
       int b = block;
    
       int mins = block * (( a + b - 1 ) / b );
    
       return new DateTime( dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0 ).AddMinutes( mins );
    }
