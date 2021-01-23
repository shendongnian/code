    [Route("/events/{EventId}/reviews", "GET")]
    public class EventReviews 
    {
       public int EventId { get; set; }
    }
    
    [Route("/events/{EventId}/reviews/{Id}", "GET")]
    public class GetEventReview
    {
       public int EventId { get; set; }
       public int Id { get; set; }
    }
    
    [Route("/events/{EventId}/reviews", "POST")]
    public class CreateEventReview
    {
       public int EventId { get; set; }
       public string Comments { get; set; }
    }
