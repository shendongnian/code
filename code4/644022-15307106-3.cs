    void Main()
    {
        var seed = new int[] { 1, 2, 3, 4, 5, 6 };
        var found = new HashSet<int>();
        var mults = seed.ToObservable()
                        .Feedback(i =>
                                  {
                                      return Observable.Range(0, 5)
                                             .Select(r => r * i)
                                             .TakeWhile(v => v < 100)
                                             .Where(v => found.Add(v));
                                  },
                                  i => Observable.Return(i));
        using (var disp = mults.Dump())
        {
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
    static IDisposable Dump<T>(this IObservable<T> source)
    {
        return source.Subscribe(item => Console.WriteLine(item),
                                ex => Console.WriteLine("Error occurred in dump observable: " + ex.ToString()),
                                () => Console.WriteLine("Dump completed"));
    }
