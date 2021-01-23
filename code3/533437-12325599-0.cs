    // CommonExtensions.cs
    public static T[] NewArray<T> (int length) where T : class, new ()
    {
        var result = new T[length] ;
        for (int i = 0 ; i < result.Length ; ++i)
             result[i] = new T () ;
        return result ;
    }
    // elsewhere
    var queues = Extensions.NewArray<Queue<int>> (10) ;
