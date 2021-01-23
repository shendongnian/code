    // From thread servicing request.
    var sc = SynchronizationContext.Current;
    
    // Run the task
    Task t = Task.Run(() => {
        // Do other stuff.
        // ...
    
        // The value to get from the session.
        string sessionValue = null;
    
        // Need to get something from the session?
        sc.Post(() => {
            // Get the value.
            sessionValue = HttpContext.Current.Session["sessionValue"];
        }
       
        // Do other stuff.
        // ...
    });
