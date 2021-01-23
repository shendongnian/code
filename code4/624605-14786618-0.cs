    public interface ICost // (only an interface for the sake of keeping this example short)
    {
        int Price { get; }
        int TurnsToMake { get; }
    }
    Lazy<Buildings, ICost> building = …;
    if (building.Metadata.Price < …)
    {
        var instantiatedBuilding = building.Value;
    }
