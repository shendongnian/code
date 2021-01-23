    static Random r = new Random();
    public IObservable<string> GetSource(string sourceName)
    {
        Console.WriteLine("Source {0} invoked", sourceName);
        return r.Next(0, 10) < 5 
            ? Observable.Empty<string>() 
            : Observable.Return("Article from " + sourceName);
    }
    
    void Main()
    {
        var query = GetSource("A")
            .SwitchIfEmpty(() => GetSource("B"))
            .SwitchIfEmpty(() => GetSource("C"));
    	
        using(query.Subscribe(Console.WriteLine))
        {
            Console.ReadLine();
        }			
    }
