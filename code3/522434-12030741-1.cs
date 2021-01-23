    //create delegate to get private _bit field
    var par = Expression.Parameter(typeof(BigInteger));
    var bits = Expression.Field(par, "_bits");
    var lambda = Expression.Lambda(bits, par);
    var func = (Func<BigInteger, uint[]>)lambda.Compile();
    //test call our delegate
    var bigint = BigInteger.Parse("3498574578238348969856895698745697868975687978");
    int time = Environment.TickCount;
    for (int y = 0; y < 10000000; y++)
    {
        var x = func(bigint);
    }
    Console.WriteLine(Environment.TickCount - time);
    //compare time to ToByteArray
    time = Environment.TickCount;
    for (int y = 0; y < 10000000; y++)
    {
        var x = bigint.ToByteArray();
    }
    Console.WriteLine(Environment.TickCount - time);
