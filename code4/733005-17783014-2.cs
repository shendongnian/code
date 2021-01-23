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
        string Name { get; set; }
        string Vineyard { get; set; }
        WineColour Colour { get; set; }
        WineRegion Region { get; set; }
        GrapeVariety Variety { get; set; }
    }
    class WineBottle
    {
        Wine Contents { get; set; }
        int Millilitres { get; set; }
        int? vintage { get; set; }
    }
    class Bin : WineBottle
    {
        int Number { get; set; }
        int Quantity { get; set; }
    }
    class Cellar : ICollection<WineBottle> 
    {
    }
