    public class MyMemoryAppender : MemoryAppender
    {
        public LoggingEvent[] GetAndClearEvents()
        {
            lock (m_eventList.SyncRoot)
            {
                var events = (LoggingEvent[]) m_eventsList.ToArray(typeof(LoggingEvent));
                m_eventsList.Clear();
                return events;
            }
        }
    }
