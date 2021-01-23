    public class FeedViewModel
    {
       ..
       public FeedItem[] FeedItems { get; set; }
    }
    public class FeedItem
    {
       public string Title { get; set; }
       public string Description { get; set; }
       public DateTime Date { get; set; }
    }
