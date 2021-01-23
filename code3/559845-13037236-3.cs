    // Get the values needed in the background thread here.
    var values = {
        SessionValue = HttpContext.Current.Session["sessionValue"];
    };
    
    // Run the task
    Task t = Task.Run(() => {
        // Do other stuff.
        // ...
    
        // Work with the session value.
        if (values.SessionValue == ...)
       
        // Do other stuff.
        // ...
    });
