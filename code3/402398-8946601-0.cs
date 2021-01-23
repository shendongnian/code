        public class GraphPointWithMeta
    {
        [Key]
        public Guid PK { get; set; }
        public string SeriesName { get; set; } 
        public string EntityName { get; set; }
        public double Amount { get; set; }
        public GraphPointWithMeta(string seriesName, string entityName, double amount)
        {
            PK = Guid.NewGuid();
            SeriesName = seriesName;
            EntityName = entityName;
            Amount = amount;
        }
        // Default ctor required.
        public GraphPointWithMeta()
        {
            PK = Guid.NewGuid();
        }
    }
