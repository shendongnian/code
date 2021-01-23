    [DllImport ("libc")]
    private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);
    enum Signal {
        SIGBUS = 10,
        SIGSEGV = 11
    }
    static void EnableCrashReporting ()
    {
        IntPtr sigbus = Marshal.AllocHGlobal (512);
        IntPtr sigsegv = Marshal.AllocHGlobal (512);
        // Store Mono SIGSEGV and SIGBUS handlers
        sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
        sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);
        // Enable crash reporting libraries
        EnableCrashReportingUnsafe ();
        // Restore Mono SIGSEGV and SIGBUS handlers            
        sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
        sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);
        Marshal.FreeHGlobal (sigbus);
        Marshal.FreeHGlobal (sigsegv);
    }
    static void EnableCrashReportingUnsafe ()
    {
        // Run your crash reporting library initialization code here--
        // this example uses HockeyApp but it should work well
        // with TestFlight or other libraries.
        // Verify in documentation that your library of choice
        // installs its sigaction hooks before leaving this method.
        var manager = BITHockeyManager.SharedHockeyManager;
        manager.Configure (HockeyAppId, null);
        manager.StartManager ();
    }
