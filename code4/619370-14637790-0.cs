    public class Match
    {
        public string Id { get; set; }
        public string Name { get; set; } // or whatever
    }
    public class Vote
    {
        public string Id { get; set; }
        public string MatchId { get; set; }
        public string UserId { get; set; }
        public bool YeaOrNay { get; set; } // or whatever
    }
