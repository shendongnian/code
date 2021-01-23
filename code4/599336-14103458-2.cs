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
        catch (Exception)
        {
            var ex1 = t1.Exception.InnerException;
            var ex2 = t2.Exception.InnerException;
            var ex3 = t3.Exception.InnerException;
            throw;
        }
        return View();
    }
