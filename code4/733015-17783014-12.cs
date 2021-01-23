    enum WineColour
    {
        Red,
        White,
        Rose
    }
    enum WineRegion
    {
        Bordeaux,
        Rioja,
        Alsace,
        ...
    }
    enum GrapeVariety
    {
        Cabernet Sauvignon,
        Merlot,
        Ugni Blanc,
        Carmenere,
        ...
    }
    class Wine
    {
        public string Name { get; set; }
        public string Vineyard { get; set; }
        public WineColour Colour { get; set; }
        public WineRegion Region { get; set; }
        public GrapeVariety Variety { get; set; }
    }
    class WineBottle
    {
        public Wine Contents { get; set; }
        public int Millilitres { get; set; }
        public int? vintage { get; set; }
    }
    class Bin : WineBottle
    {
        int Number { get; set; }
        int Quantity { get; set; }
    }
    class Cellar : ICollection<WineBottle> 
    {
        ...
    }
