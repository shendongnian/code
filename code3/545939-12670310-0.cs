    internal class EventManager
    {
        private static List<EventRecord> s_listEvents = new List<EventRecord>();
        private static object _syncObject = new object();
    
    
        public static void AddEvent(EventRecord record)
        {
            record.EventDate = DateTime.Now;
            lock(_syncObject)
            {
               s_listEvents.Add(record); 
            }
            
        }
    
        public static List<EventRecord> GetRecordsByDate(DateTime date)
        {
            lock (_syncObject)
            {
                 var r = (from l in s_listEvents
                     where l.EventDate >= date
                     select l).ToList<EventRecord>();
                 
            return r;
            }
           
        }
    }
