    public static bool ContainsNTimes<T>(this IEnumerable<T> sequence, T element, int duplicateCount)
    {
        if (element == null)
            throw new ArgumentNullException("element");
        if (!sequence.Any())
            throw new ArgumentException("Sequence must contain elements", "sequence");
        if (duplicateCount < 1)
             throw new ArgumentException("DuplicateCount must be greater 0", "duplicateCount");
        bool containsNTimes = sequence.Where(i => i.Equals(element))
                                .Take(duplicateCount)
                                .Count() == duplicateCount;
        return containsNTimes;
    }
