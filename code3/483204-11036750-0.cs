    try
    {
        SomethingBad();
    }
    catch(AggregateException ae)
    {
        ae.handle(x => {
            Console.WriteLine(x.Message);
        });
    }
