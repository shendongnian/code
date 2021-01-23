    public static class ErrorHandler
        {
            /// <summary>
            ///     Tasks the scheduler on unobserved task exception.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="unobservedTaskExceptionEventArgs">
            ///     The <see cref="UnobservedTaskExceptionEventArgs" /> instance containing
            ///     the event data.
            /// </param>
            public static void TaskSchedulerOnUnobservedTaskException(object sender,
                UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
            {
                var newExc = new Exception("TaskSchedulerOnUnobservedTaskException",
                    unobservedTaskExceptionEventArgs.Exception);
                LogUnhandledException(newExc);
            }
    
            /// <summary>
            ///     Currents the domain on unhandled exception.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="unhandledExceptionEventArgs">
            ///     The <see cref="UnhandledExceptionEventArgs" /> instance containing the event
            ///     data.
            /// </param>
            public static void CurrentDomainOnUnhandledException(object sender,
                UnhandledExceptionEventArgs unhandledExceptionEventArgs)
            {
                var newExc = new Exception("CurrentDomainOnUnhandledException",
                    unhandledExceptionEventArgs.ExceptionObject as Exception);
                LogUnhandledException(newExc);
            }
    
            /// <summary>
            ///     Logs the unhandled exception.
            /// </summary>
            /// <param name="exception">The exception.</param>
            internal static void LogUnhandledException(Exception exception)
            {
                try
                {
                    string error =
                        $"Exception Caught:{DateTime.Now:F} The Error Message IS {exception.Message}\n\r full stack trace is {exception.ToString()} ";
    #if DEBUG
                    const string errorFileName = "errorlog.txt";
                    var libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    // iOS: Environment.SpecialFolder.Resources
                    var errorFilePath = System.IO.Path.Combine(libraryPath, errorFileName);
                    System.IO.File.WriteAllText(errorFilePath, error);
                    Android.Util.Log.Error("Crash Report error not handled", ex.ToString());
        #else
                        // Log to Android Device Logging.
                        Android.Util.Log.Error("Crash Report", error);
        #endif
                    }
                    catch (Exception ex)
                    {
                        Android.Util.Log.Error("Crash Report error not handled", ex.ToString());
                        // just suppress any error logging exceptions
                    }
                }
            }
