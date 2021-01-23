    using Int32Condition = System.Collections.Generic.Dictionary<System.Func<System.Int32, System.Boolean>, System.Action>;
    ...
        var cases = new Int32Condition()
        { 
            { x => x < 3 ,    () => Console.WriteLine("Smaller than 3")   } ,
            { x => x < 30 ,   () => Console.WriteLine("Smaller than 30")  } ,
            { x => x < 300 ,  () => Console.WriteLine("Smaller than 300") } 
        };
