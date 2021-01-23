    public struct Point
    {
    	public double X;
    	public double Y;
    	
    	public double Distance(Point otherPoint)
    	{
    		double deltaX = this.X - otherPoint.X;
    		double deltaY = this.Y - otherPoint.Y;
            return System.Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    	}
    	
    	public override string ToString()
    	{
    		return String.Format("({0}, {1})", X, Y);
    	}
    }
    
    public struct Polar
    {
    	public double Radius;
    	public double Angle;
    	
    	public double X { get { return Radius * System.Math.Cos(Angle); } }
        public double Y { get { return Radius * System.Math.Sin(Angle); } }
    	
    	public Point ToCartesian()
    	{
    		return new Point() { X = X, Y = Y };
    	}
    }
    
    public class Circle
    {
    	public double Radius { get; set; }
    	public Point Position { get; set; }
    }
