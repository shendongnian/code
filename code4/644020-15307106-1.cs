    void Main()
        var seed = {1, 2, 3, 4, 5, 6};
        var found = new HashSet<int>();
        var mults = seed.ToObservable() 
                    .Feedback((i) =>
                              {
                                  return Observable.Range(0, 5) 
                                         .Select((r) => r * i)
                                         .TakeWhile((v) => v < 100)
                                         .Where((v) => found.Add(v));
                              },
                              (i) => Observable.Return(i);)
        using (disp = mults.Dump())
        {
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
