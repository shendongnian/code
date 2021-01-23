    try
    {
        await Task.WhenAll(
            Task.Factory.StartNew(() => { throw new NullReferenceException(); }),
            Task.Factory.StartNew(() => { throw new ArgumentException(); }));
    }
    catch (AggregateException ex)
    {
        // this catch will never be target
        Console.WriteLine("** {0} **", ex.GetType().Name);
    }
    catch (Exception ex)
    {
        Console.WriteLine("## {0} ##", ex.GetType().Name);
    }
