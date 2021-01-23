    internal class EventManager
    {
        static ReaderWriterLock rwl = new ReaderWriterLock();
        private static List<EventRecord> s_listEvents = new List<EventRecord>();
        public static void AddEvent(EventRecord record)
        {
            record.EventDate = DateTime.Now;
            rwl.AcquireWriterLock(0);
            try
            {
                s_listEvents.Add(record);
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }
        public static List<EventRecord> GetRecordsByDate(DateTime date)
        {
            rwl.AcquireReaderLock(0);
            try
            {
                var r = (from l in s_listEvents
                         where l.EventDate >= date
                         select l).ToList<EventRecord>();
                return r;
            }
            finally
            {
                rwl.ReleaseReaderLock();
            }
        }
    }
