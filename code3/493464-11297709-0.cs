    public class Sport
    {
        public virtual int SportId { get; set; }
        // Other properties
    }
    public class Result : Entity
    {
        public virtual ResultId { get; set; }
        public virtual Competitor Competitor { get; set; }
        public virtual Sport Sport { get; set; }
        // Other properties
    }
    
    public class Competitor
    {
        public virtual int CompetitorId { get; set; }
        public virtual IList<Result> Results { get; set; }
        // Other properties
    }
