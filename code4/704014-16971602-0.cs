    void Main()
    {
        var src = Enumerable.Range(0, 10);
        var observable = Observable.Create<int>(obs =>
        {
            foreach(var item in src)
            {
                obs.OnNext(item);
            }
            return Disposable.Create(()=>{});
        });
        
        using(observable.Subscribe(Console.WriteLine))
        {
            Console.ReadLine();
        }
    }
