    public IEnumerable<long> GetMissingNumbers(long rangeStart, long rangeEnd,
                                    IEnumerable<long> numbers)
    {
        return Range(rangeStart, rangeEnd - rangeStart)
                .Except(numbers);
    }
