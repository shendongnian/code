    IEnumerable<long> GetMissingNumbers(long rangeStart, long rangeEnd, 
                                        IEnumerable<long> numbers)
    {
        var existingNumbers = new HashSet<long>(numbers);
    
        for(long n = rangeStart;n<=rangeEnd;n++)
        {
            if(!existingNumbers.Contains(n))
                yield return n;
        }
    }
