    public class VotingContext : DbContext
    {
        public DbSet<Poll> Polls{get;set;}
        public DbSet<Vote> Votes{get;set;}
        public DbSet<Voter> Voters{get;set;}
        public DbSet<Candidacy> Candidates{get;set;}
    }
    VotingContext.Votes.RemoveRange(VotingContext.Votes)
