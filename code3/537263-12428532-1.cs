    var task = <task 1>.ContinueWith(t => {
        // Dispose of the preceding task when done.
        using (t)
        {
             // Do task 2.
        }
    });
