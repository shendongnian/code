    // Could get ILoggingContext into the ctx variable from the
    // derived instance via a method argument,
    // or abstract or virtual method call - here it's done inline
    ILoggingContext ctx = Kernel.Bind<ILoggingContext>()
        .To<Application1LoggingContext>().InThreadScope(); 
    Parallel.ForEach(someEnumerable, iter =>
        {
            // this code can refer to ctx
        });
