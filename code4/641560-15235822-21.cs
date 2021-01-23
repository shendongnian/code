    [Route("/events", "GET")]
    [Route("/events/category/{Category}", "GET")] //*Optional top-level views
    public class Events : IReturn<EventsResponse>
    {
       //Optional resultset filters, e.g. ?Category=Tech&Search=servicestack
       public string Category { get; set; } 
       public string Search { get; set; }
    }
    
    [Route("/events", "POST")]
    public class CreateEvent : IReturn<Event>
    {
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
    }
    
    [Route("/events/{Id}", "GET")]
    [Route("/events/code/{EventCode}", "GET")] //*Optional
    public class GetEvent : IReturn<Event>
    {
       public int Id { get; set; }
       public string EventCode { get; set; } //Alternative way to fetch an Event
    }
    
    [Route("/events/{Id}", "PUT")]
    public class UpdateEvent : IReturn<Event>
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
    }
