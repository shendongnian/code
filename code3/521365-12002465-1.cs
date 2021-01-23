    public enum ApplicationExecutionState
    {
        // Summary:
        //     The app is not running.
        NotRunning = 0,
        //
        // Summary:
        //     The app is running.
        Running = 1,
        //
        // Summary:
        //     The app is suspended.
        Suspended = 2,
        //
        // Summary:
        //     The app was terminated after being suspended.
        Terminated = 3,
        //
        // Summary:
        //     The app was closed by the user.
        ClosedByUser = 4,
    }
