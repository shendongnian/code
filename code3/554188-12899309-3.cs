    public class IfContextSetFilterAppender : log4net.Appender.AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            bool logThisEntry = false;
            string serviceMethodBeingLogged;
    
            foreach (object p in loggingEvent.GetProperties())
            {
                System.Collections.DictionaryEntry dEntry = (System.Collections.DictionaryEntry)p;
                if (dEntry.Key == "logThisMethod")
                {
                    logThisEntry = true;
                    serviceMethodBeingLogged = dEntry.Value.ToString();
                }
            }
    
            if (!logThisEntry)
                return; // don't log it.
    
            // log it.
        }
    }
