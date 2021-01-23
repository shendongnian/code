    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return permutations(source.ToArray());
    }
    
    private static IEnumerable<IEnumerable<T>> permutations<T>(IEnumerable<T> source)
    {
        IEnumerable<T> enumerable = source as List<T> ?? source.ToList();
        var c = enumerable.Count();
        if (c == 1)
            yield return enumerable;
        else
            for (int i = 0; i < c; i++)
                foreach (var p in permutations(enumerable.Take(i).Concat(enumerable.Skip(i + 1))))
                    yield return enumerable.Skip(i).Take(1).Concat(p);
    }
    
    private static IEnumerable<string> Subsets(char[] chars)
    {
        List<string> subsets = new List<string>();
    
        for (int i = 1; i < chars.Length; i++)
        {
            subsets.Add(chars[i - 1].ToString(CultureInfo.InvariantCulture));
            int i1 = i;
            List<string> newSubsets = subsets.Select(t => t + chars[i1]).ToList();
            subsets.AddRange(newSubsets);
        }
        subsets.Add(chars[chars.Length - 1].ToString(CultureInfo.InvariantCulture));
        return subsets;
    }
    private static void Main()
    {
        char[] chars = new[]{'a','b','c'};
        var subsets = Subsets(chars);
        List<string> allPossibleCombPerm = 
            subsets.SelectMany(Permutations).Select(permut => string.Join("", permut)).ToList();
        allPossibleCombPerm.ForEach(Console.WriteLine);
    }
