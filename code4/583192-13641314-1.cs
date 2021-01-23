    namespace Microsoft.WindowsAzure.Diagnostics
    {
        // Summary:
        //     Defines a standard set of logging levels.
        public enum LogLevel
        {
            // Summary:
            //     Logs all events at all levels.
            Undefined = 0,
            //
            // Summary:
            //     Logs a critical alert.
            Critical = 1,
            //
            // Summary:
            //     Logs an error.
            Error = 2,
            //
            // Summary:
            //     Logs a warning.
            Warning = 3,
            //
            // Summary:
            //     Logs an informational message.
            Information = 4,
            //
            // Summary:
            //     Logs a verbose message.
            Verbose = 5,
        }
    }
