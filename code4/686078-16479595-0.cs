    public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
    {
      return k == 0 ? new[] { new T[0] } :
        elements.SelectMany((e, i) =>
          Combinations(elements.Skip(i + 1),k - 1).Select(c => (new[] {e}).Concat(c)));
    }
    
    public static void Main()
    {
        var x = new int[] { 1, 2, 3, 4, 5, 6 };
        var limit = 3;
        IEnumerable<IEnumerable<int>> result = Combinations(x, limit);
             
        foreach(var combi in result)
            Console.WriteLine(String.Join("+", combi.Select(a=>a.ToString()).ToArray()) + "=" + combi.Sum());
        Console.WriteLine("Total: " + result.Sum(c => c.Sum())); // 201
    }
