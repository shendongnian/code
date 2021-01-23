    void Main()
    {
        // A faked up source
        var source = new Subject<bool>();
        
        var query = new MyObservable<bool>(source);
        using(query.Subscribe(Console.WriteLine))
        {
            // nothing on output...
            source.OnNext(true);
            // still nothing on output...
            source.OnNext(false);
            Console.ReadLine();
        }
        // dispose fires, outputs "Sorry, you never got a subscription"
    }
