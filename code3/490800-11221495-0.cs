            string logName = "_myEventLogSource";
            if (!EventLog.SourceExists(logName))
                EventLog.CreateEventSource(logName, logName);
            EventLogTraceListener myTraceListener = new EventLogTraceListener(logName);
            // Add the event log trace listener to the collection.
            System.Diagnostics.Trace.Listeners.Add(myTraceListener);
            // Write output to the event log.
            System.Diagnostics.Trace.WriteLine("Test output");
