    internal class Combination
    {
        internal int Num;
        internal IEnumerable<Combination> Combinations;
    }
    
    internal static IEnumerable<Combination> GetCombinationTrees(int num, int max)
    {
        return Enumerable.Range(1, num)
                         .Where(n => n <= max)
                         .Select(n =>
                             new Combination
                             {
                                 Num = n,
                                 Combinations = GetCombinationTrees(num - n, n)
                             });
    }
    
    internal static IEnumerable<IEnumerable<int>> BuildCombinations(
                                                   IEnumerable<Combination> combinations)
    {
        if (combinations.Count() == 0)
        {
            return new[] { new int[0] };
        }
        else
        {
            return combinations.SelectMany(c =>
                                  BuildCombinations(c.Combinations)
                                       .Select(l => new[] { c.Num }.Concat(l))
                                );
        }
    }
    
    public static IEnumerable<IEnumerable<int>> GetCombinations(int num)
    {
        var combinationsList = GetCombinationTrees(num, num);
    
        return BuildCombinations(combinationsList);
    }
    
    public static void PrintCombinations(int num)
    {
        var allCombinations = GetCombinations(num);
        foreach (var c in allCombinations)
        {
            Console.WriteLine(string.Join(", ", c));
        }
    }
