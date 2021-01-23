    /// <summary>
    /// Stop execution for a specific amount of time without blocking the UI
    /// </summary>
    /// <param name="interval">The time to wait in milliseconds</param>
    public static void Wait(int interval)
    {
        ExecuteWait(() => Thread.Sleep(interval));
    }
    
    public static void ExecuteWait(Action action)
    {
        var waitFrame = new DispatcherFrame();
    
        // Use callback to "pop" dispatcher frame
        IAsyncResult op = action.BeginInvoke(dummy => waitFrame.Continue = false, null);
    
        // this method will block here but window messages are pumped
        Dispatcher.PushFrame(waitFrame);
    
        // this method may throw if the action threw. caller's responsibility to handle.
        action.EndInvoke(op);
    }
