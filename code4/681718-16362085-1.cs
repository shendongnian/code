    public class MyContext : DbContext
    {
        public DbSet<TimeReport> TimeReport { get; set; }
        public DbSet<Dossier> Dossier { get; set; }
        public DbSet<BU> BU { get; set; }
    }
  
    public class BU
    {
        public int BUId { get; set; }
        public string Code { get; set; }
    }
  
    public class Dossier
    {
        public int DossierId { get; set; }
        [ForeignKey("BU")]
        public int BUId { get; set; }
        public BU BU { get; set; }
    }
  
    public class TimeReport
    {
        public int TimeReportId { get; set; }
        [ForeignKey("Dossier")]
        public int DossierId { get; set; }
        public Dossier Dossier { get; set; }
    }
