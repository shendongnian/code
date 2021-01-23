    public class MySolutionForDestinations
    {
        public int DestinationId { get; set; } //primary key
        public int ParentDestinationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DestinationLevel Level { get; set; }
    }
    public enum DestinationLevel
    {
        Country = 0,
        Region = 1,
        City = 2
    }
