    [Route("/events/{EventId}/reviews", "GET")]
    public class EventReviews : IReturn<EventReviewsResponse>
    {
       public int EventId { get; set; }
    }
    
    [Route("/events/{EventId}/reviews/{Id}", "GET")]
    public class GetEventReview : IReturn<EventReview>
    {
       public int EventId { get; set; }
       public int Id { get; set; }
    }
    
    [Route("/events/{EventId}/reviews", "POST")]
    public class CreateEventReview : IReturn<EventReview>
    {
       public int EventId { get; set; }
       public string Comments { get; set; }
    }
