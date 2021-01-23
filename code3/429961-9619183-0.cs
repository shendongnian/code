    var asyncTestConn = Task.Factory.StartNew(() => TestConnection(conn, bShowErrMsg));
    // Henk's "MyFinishCode" takes a parameter representing the completed
    // or faulted connection-testing task.
    // Anything that depended on your "return asyncTestConn.Result;" statement
    // needs to move into the callback method.
    asyncTestConn.ContinueWith(task =>
        {
            switch (task.Status)
            {
                // Handle any exceptions to prevent UnobservedTaskException.
                case TaskStatus.Faulted: /* Error-handling logic */ break;
                case TaskStatus.RanToCompletion: /* Use task.Result here */ break;
            }
        },
        // Using this TaskScheduler schedules the callback to run on the UI thread.
        TaskScheduler.FromCurrentSynchronizationContext());
