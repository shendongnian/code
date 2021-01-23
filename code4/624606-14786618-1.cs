    public class Cost
    {
        public int Price { get; set; }
        public int TurnsToMake { get; set; }
    }
    var lazyBuildings = new Lazy<Buildings, Cost>(
            valueFactory: () => new Walls(),
            metadata: new Cost { Price = 200, TurnsToMake = 5 });
    if (lazyBuildings.Metadata.Price < …)
    {
        var buildings = lazyBuildings.Value;
    }
