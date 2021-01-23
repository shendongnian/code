    static void Main(string[] args)
    {
        var observableNums = Observable.Interval(TimeSpan.FromSeconds(1))
                                       .Select(x => (int)x);
        var observableOdds = FilterOdds(observableNums);
        observableOdds.Subscribe(Console.WriteLine);
        var enumerableNums = new[] { 1, 2, 3, 4, 5, 6 };
        var enumerableOdds = FilterOdds(enumerableNums.ToObservable());
        foreach (var i in enumerableOdds.ToEnumerable())
            Console.WriteLine(i);
        Console.ReadKey();
    }
    static IObservable<int> FilterOdds(IObservable<int> nums)
    {
        return nums.Where(i => i % 2 == 1);
    } 
