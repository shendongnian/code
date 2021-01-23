    public class VotingContext : DbContext
    {
        public DbSet<Vote> Votes{get;set;}
        public DbSet<Poll> Polls{get;set;}
        public DbSet<Voter> Voters{get;set;}
        public DbSet<Candidacy> Candidates{get;set;}
    }
