    public interface IShape
    {
        string Id { get; set; }
        GeoLocationTypes Type { get; set; }
        Bounds Bounds { get; set; }
    }
    
    public interface ICircle : IShape
    {
        float Radius { get; set; }
        Coordinates Center { get; set; }
    }
    
    public interface IRectangle : IShape
    {
    }
