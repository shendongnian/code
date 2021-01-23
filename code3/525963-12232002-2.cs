    public class MyRadiansShape
    {
    	public Radians Rotation { get; set; }
    }
    
    public class MyDegreesShape
    {
    	public Degrees Rotation { get; set; }
    }
    public static void PrintRotation(Degrees degrees, Radians radians)
    {
    	Console.WriteLine(String.Format("Degrees: {0}, Radians: {1}", degrees.Value, radians.Value));
    }
