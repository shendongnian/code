            string logSource = "_myEventLogSource";
            if (!EventLog.SourceExists(logSource))
                EventLog.CreateEventSource(logSource, logSource);
            EventLogTraceListener myTraceListener = new EventLogTraceListener(logSource);
            // Add the event log trace listener to the collection.
            System.Diagnostics.Trace.Listeners.Add(myTraceListener);
            // Write output to the event log.
            System.Diagnostics.Trace.WriteLine("Test output");
