    using System;
    using System.Diagnostics.Eventing.Reader;
    
    class Program
    {
        static void Main(string[] args)
        {
            EventLogQuery subscriptionQuery = 
                new EventLogQuery("Microsoft-Windows-Audio/CaptureMonitor", 
                    PathType.LogName, "*");
            using (EventLogReader logReader = 
                new EventLogReader(subscriptionQuery))
            {
                DisplayEventAndLogInformation(logReader);
            }
        }
        private static void DisplayEventAndLogInformation(EventLogReader logReader)
        {
            for (EventRecord eventInstance = logReader.ReadEvent();
                null != eventInstance; eventInstance = logReader.ReadEvent())
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Event ID: {0}", eventInstance.Id);
                Console.WriteLine("Publisher: {0}", eventInstance.ProviderName);
                try
                {
                    Console.WriteLine("Description: {0}", 
                        eventInstance.FormatDescription());
                }
                catch (EventLogException)
                {
                    // The event description contains parameters, 
                    // and no parameters were passed to the 
                    // FormatDescription method, so an exception is thrown.
                }
                // Cast the EventRecord object as an EventLogRecord 
                // object to access the EventLogRecord class properties
                EventLogRecord logRecord = (EventLogRecord)eventInstance;
                Console.WriteLine("Container Event Log: {0}", 
                    logRecord.ContainerLog);
            }
        }
    }
