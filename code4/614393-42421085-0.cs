    static void EnableCrashReporting ()
    {
        try {
        } finally {
            Mono.Runtime.RemoveSignalHandlers ();
            try {
                EnableCrashReportingUnsafe();
            } finally {
                Mono.Runtime.InstallSignalHandlers ();
            }
        }
    }
    
    static void EnableCrashReportingUnsafe ()
    {
        // Run your crash reporting library initialization code here--
        // this example uses HockeyApp but it should work well
        // with TestFlight or other libraries.
    
        // Verify in documentation that your library of choice
        // installs its sigaction hooks before leaving this method.
    
        // Have in mind that at this point Mono will not handle
        // any NullReferenceExceptions, if there are any 
        // NullReferenceExceptions on any thread (not just the current one),
        // then the app will crash.
        var manager = BITHockeyManager.SharedHockeyManager;
        manager.Configure (HockeyAppId, null);
        manager.StartManager ();
    }
