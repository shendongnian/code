    public class Point
    {
    	private double? x;
    	private double? y;
    
    	public bool IsXDefined { get { return this.x.HasValue; } }
    
    	public bool IsYDefined { get { return this.y.HasValue; } }
    
    	// Returns an undefined value (default(double)) in case X is not defined
    	// This is a part of the contract that X is valid if, and only if IsXDefined is true.
    	public double X { get { return x ?? default(double); } }
    
    	public double Y { get { return y ?? default(double); } }
    }
    Point p = new ...
    if (p.IsXDefined)
    {
    	double zz = p.X ....
    }
