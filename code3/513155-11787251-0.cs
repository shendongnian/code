    void Main()
    {
        var eachMinuteSequence = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(1));
    
        var symbols = new[] { "GOOG", "MSFT", "AAPL" };
    
        Action<long> eachMinuteAction = async _ =>
        {
            var tasks = StartWebCalls(symbols);
            var results = await Task.WhenAll(tasks);
            // do something with the results
        };
        eachMinuteSequence.Subscribe(eachMinuteAction);
    }
    
    // Define other methods and classes here
    public Task<decimal>[] StartWebCalls(IEnumerable<string> stockSymbols)
    {
        return (
            from symbol in stockSymbols
            select GoToWeb(symbol)
        ).ToArray();
    }
    
    public async Task<decimal> GoToWeb(string Sym){throw new NotImplementedException();}
