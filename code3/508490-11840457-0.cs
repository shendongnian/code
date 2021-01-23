    public class Destination
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public List<Lodging> Lodgings { get; set; }
    }
    public class Lodging
    {
         public int LodgingId { get; set; }
         public string Name { get; set; }
         public string Owner { get; set; }
         public bool IsResort { get; set; }
         public decimal MilesFromNearestAirport { get; set; }
         public int DestinationId { get; set; }
         public Destination Destination { get; set; }
    }
    
    internal class LodgingConfiguration:EntityTypeConfiguration<Charge>
    {
        HasRequired(d=>d.Destination).WithMany(l=>l.Logings).HasForeignKey(d=>d.DestinationId)
    }
