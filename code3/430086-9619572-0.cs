    public class Coordinates
    {
    	public double Latitude { get; set; }
    	public double Longitude { get; set; }
    }
    public bool IsNear(List<Coordinates> coords, double lat, double lon, double tolerance)
    {
    	return coords.Any(p => Math.Abs(p.Latitude - lat) < tolerance || Math.Abs(p.Longitude - lon) < tolerance);
    }
