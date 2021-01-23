    public static IEnumerable<int[]> GetLists(int[] numbers, int length)
    {
        if(length == 1)
        {
            foreach(var i in numbers)
            {
                yield return new[] { i };
            }
        }
        foreach(var i in numbers)
        {
            foreach(var list in GetLists(numbers, length - 1))
            {
                yield return new List<int> { i }.Concat(list).ToArray();
            }
        }
    }
