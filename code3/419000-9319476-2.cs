    public static Int32 num = 0;
    public static Int32 GetSequence() 
    { 
        return Interlocked.Increment(ref num); 
    }
    public static IEnumerable<Int32> GetSequenceRange(Int32 count) 
    { 
        var newValue = Interlocked.Add(ref num, count);
        return Enumerable.Range(newValue - count, count);
    }
