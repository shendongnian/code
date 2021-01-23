    static void Main(string[] args)
    {
        int[][] combinations = GetCombinations(8).Select(c => c.ToArray()).ToArray();
        string s = string.Join("\n", combinations.Select(c => string.Join(",", c)));
        Console.WriteLine(s);
    }
    static IEnumerable<IEnumerable<int>> GetCombinations(int count)
    {
        return GetCombinations(Enumerable.Range(1, count));
    }
    static IEnumerable<IEnumerable<int>> GetCombinations(IEnumerable<int> elements)
    {
        if (elements.Count() == 1)
            return EnumerableSingle(elements);
        return elements.SelectMany((element, index) =>
            GetCombinations(elements.ExceptAt(index)).Select(tail =>
                tail.Prepend(element)));
    }
    static IEnumerable<T> ExceptAt<T>(this IEnumerable<T> source, int index)
    {
        return source.Take(index).Concat(source.Skip(index + 1));
    }
    static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
    {
        return EnumerableSingle(element).Concat(source);
    }
    static IEnumerable<T> EnumerableSingle<T>(T element)
    {
        return Enumerable.Repeat(element, 1);
    }
