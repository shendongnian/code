    public class ChallengeDBContext : DbContext
    {
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Solution> Solutions {get; set;}
    }
    public class Challenge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public int Points { get; set; }
        public string Category { get; set; }
        public string Flag { get; set; }
        public List<Solution> SolvedBy { get; set; }
    }
    public class Solution
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
