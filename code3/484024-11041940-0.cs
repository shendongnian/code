     public class EventListModel
        {
            public EventListModel()
            {
                EventList = new List<Event>();
            }
    
            public string FormId { get; set; }
            public string ProgramId { get; set; }
            public string FormName { get; set; }
    
            public IList<Event> EventList { get; set; }
        }
