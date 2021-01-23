    public class Auction
    {
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal StartPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    // My Edit to the code Start -->
    public Nullable<DateTime> StartTime { get; set; }
    public Nullable<DateTime> EndTime { get; set; }}
    // My Edit to the code Finish <--
    }
