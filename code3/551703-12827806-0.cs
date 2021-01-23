    // You'd probably want to materialize this into an IList<T> to avoid
    // warnings about multiple iterations of an IEnumerable<T>.
    // You definitely *don't* want this to be an IQueryable<T>
    // returned from a context.
    IEnumerable<MyItem> items = ...;
    
    // The first stored procedure is called here.
    Task t1 = Task.Run(() => { 
        // Create the context.
        using (var ctx = new MyDbContext())
        // Cycle through each item.
        foreach (MyItem item in items)
        {
            // Call the first stored procedure.
            // You'd of course, have to do something with item here.
            ctx.DoSomething1(item);
        }
    });
    
    // The second stored procedure is called here.
    Task t2 = Task.Run(() => { 
        // Create the context.
        using (var ctx = new MyDbContext())
        // Cycle through each item.
        foreach (MyItem item in items)
        {
            // Call the first stored procedure.
            // You'd of course, have to do something with item here.
            ctx.DoSomething2(item);
        }
    });
    
    // Do something when both of the tasks are done.
