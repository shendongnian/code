    public class NerdDinners : System.Data.Entity.DbContext
    {
        public NerdDinners(string connString):base(connString)
        {}
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
    }
