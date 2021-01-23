    public static Int32 num = 0;
    public static Int32 GetSequence() 
    { 
        return Interlocked.Increment(ref num); 
    }
    public static IEnumerable<Int32> GetSequenceRange(Int32 num) 
    { 
        Enumerable.Range(0, num).Select(i => GetSequence()); 
    }
