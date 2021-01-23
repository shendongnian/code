    public interface IShape
    {
        string Id { get; set; }
        GeoLocationTypes Type { get; set; }
        Bounds Bounds { get; set; }
    }
    public interface IRectangle : IShape { }
    public class Rectangle : IRectangle
    {
        // No change
    }
    
    public interface ICircle : IShape
    {
        float Radius { get; set; }
        Coordinates Center { get; set; }
    }
    public class Circle : ICircle
    {
        // No change
    }
    public class Bounds
    {
        // No change
    }
    public class Coordinates
    {
        // No change
    }
