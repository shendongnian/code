    public async Task AsyncMethod()
    {
        await Task.Run(() =>
        {
            throw new Exception();
        });
    }
    public async Task<ActionResult> Index()
    {
        var t1 = Task.Run(() => { throw new Exception(); });
        var t2 = Task.Run(() => { throw new Exception();});
        var t3 = Task.Run(async () => { await AsyncMethod(); });
        try 
        {
            await Task.WhenAll(t1, t2, t3);
        }
        catch (AggregateException ex)
        {
            var count1 = ex.InnerExceptions.Count;
            var count2 = ex.Flatten().InnerExceptions.Count;
            throw;
        }
        return View();
    }
