    interface IMethods<T>
    {
      T Generate(int size, Func<int, int> generator);
       int Sum(T items);
       T BlockCopy(T items);
       T Sort(T items);
    }
    class ArrayMethods:IMethods<int[]>
    {
      public int[] Generate(int size, Func<int, int> generator)
      {
        var items = new int[size];
        for (var i = 0; i < items.Length; ++i)
          items[i] = generator(i);
        return items;
      }
      public int Sum(int[] items)
      {
        int sum = 0;
        foreach (var item in items)
          sum += item;
        return sum;
      }
      public int[] BlockCopy(int[] items)
      {
        var res = new int[items.Length / 2];
        Buffer.BlockCopy(items, items.Length / 4 * sizeof(int), res, 0, res.Length * sizeof(int));
        return res;
      }
      public int[] Sort(int[] items)
      {
        var res = new int[items.Length];
        Buffer.BlockCopy(items, 0, res, 0, items.Length * sizeof(int));
        return res;
      }
    }
    class ListMethods : IMethods<List<int>>
    {
      public List<int> Generate(int size, Func<int, int> generator)
      {
        var items = new List<int>(size);
        for (var i = 0; i < size; ++i)
          items.Add(generator(i));
        return items;
      }
      public int Sum(List<int> items)
      {
        int sum = 0;
        foreach (var item in items)
          sum += item;
        return sum;
      }
      public List<int> BlockCopy(List<int> items)
      {
        var count = items.Count / 2;
        var res = new List<int>(count);
        var start = items.Count / 4;
        for (var i = 0; i < count; ++i)
          res.Add(items[start + i]);
        return res;
      }
      public List<int> Sort(List<int> items)
      {
        var res = new List<int>(items);
        res.Sort();
        return res;
      }
    }
    class ReadOnlyCollectionMethods:IMethods<ReadOnlyCollection<int>>
    {
      public ReadOnlyCollection<int> Generate(int size, Func<int, int> generator)
      {
        return new ReadOnlyCollection<int>(Enumerable.Range(0, size).Select(generator).ToList());
      }
      public int Sum(ReadOnlyCollection<int> items)
      {
        int sum = 0;
        foreach (var item in items)
          sum += item;
        return sum;
      }
      public ReadOnlyCollection<int> BlockCopy(ReadOnlyCollection<int> items)
      {
        return new ReadOnlyCollection<int>(items.Skip(items.Count / 4).Take(items.Count / 2).ToArray());
      }
      public ReadOnlyCollection<int> Sort(ReadOnlyCollection<int> items)
      {
        return new ReadOnlyCollection<int>(items.OrderBy(s => s).ToList());
      }
    }
    static class Program
    {
      static Tuple<string, TimeSpan>[] CheckPerformance<T>(IMethods<T> methods) where T:class
      {
        var stats = new List<Tuple<string, TimeSpan>>();
        T source = null;
        foreach (var info in new[] 
          { 
            new {Name = "Generate", Method = new Func<T, T>(items => methods.Generate(10000000, i => i % 2 == 0 ? -i : i))}, 
            new {Name = "Sum", Method =  new Func<T, T>(items => {Console.WriteLine(methods.Sum(items));return items;})}, 
            new {Name = "BlockCopy", Method = new Func<T, T>(items => methods.BlockCopy(items))}, 
            new {Name = "Sort", Method = new Func<T, T>(items => methods.BlockCopy(items))}, 
            new {Name = "Sum", Method =  new Func<T, T>(items => {Console.WriteLine(methods.Sum(items));return items;})}, 
          }
         )
        {
          int count = 10;
          var stopwatch = new Stopwatch();
          stopwatch.Start();
          T res = null;
          for (var i = 0; i < count; ++i)
            res = info.Method(source);
          stopwatch.Stop();
          source = res;
          stats.Add(new Tuple<string, TimeSpan>(info.Name, stopwatch.Elapsed));
        }
        return stats.ToArray();
      }
      static void Main()
      {
        var arrayStats = CheckPerformance(new ArrayMethods());
        var listStats = CheckPerformance(new ListMethods());
        var rcStats = CheckPerformance(new ReadOnlyCollectionMethods());
        Console.WriteLine("       Array                List        ReadOnlyCollection         Penalties      Method");
        for(var i = 0; i < arrayStats.Length; ++i)
        {
          Console.WriteLine("{0}    {1}    {2}    1 vs {3,4:f1}  vs {4,4:f1}   {5}", arrayStats[i].Item2, listStats[i].Item2, rcStats[i].Item2, 
            listStats[i].Item2.TotalSeconds / arrayStats[i].Item2.TotalSeconds,
            rcStats[i].Item2.TotalSeconds / arrayStats[i].Item2.TotalSeconds, arrayStats[i].Item1);
        }
      }
