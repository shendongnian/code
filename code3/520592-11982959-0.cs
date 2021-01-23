    public class Event
    {
        private readonly int _eventId;
        private readonly string _eventTitle;
        private readonly DateTime _dateTimeStart;
    
        public Event(int eventId, string eventTitle, DateTime dateTimeStart)
        {
            _eventId = eventId;
            _eventTitle = eventTitle;
            _dateTimeStart = dateTimeStart;
        }
    
        public int EventId { get { return _eventId; } }
        public string EventTitle { get { return _eventTitle; } }
        public DateTime DateTimeStart{ get { return _dateTimeStart; } }
    }
    public IQueryable<Event> FindUpcomingEventsCustom(int daysFuture) 
    { 
        DateTime dateTimeNow = DateTime.UtcNow; 
        DateTime dateTimeFuture = dateTimeNow.AddDays(daysFuture); 
        return db.EventCustoms
                 .Where(x => x.DataTimeStart > dateTimeNow
                             && x.DataTimeStart <= dateTimeFuture) 
                 .Select(y => new Event(y.EventId, y.EventTitle, y.DataTimeStart)); 
    } 
