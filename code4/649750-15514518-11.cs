     public List<string[]> divStrings(int count, string[] array)
     {
        long remainder;
        long divCount = Math.DivRem(array.Count(), count, out remainder);
        int ajustedCount = (int)((divCount > remainder) 
                           ? (divCount / remainder) 
                           : (remainder / divCount)) + count;
        int groupCount = (ajustedCount * divCount) > array.Count() 
            ? (int)divCount
            : (int)divCount++;
        return Enumerable.Range(0, groupCount).Select(g => array.Skip(g * ajustedCount).Take(ajustedCount).ToArray()).ToList();
     }
