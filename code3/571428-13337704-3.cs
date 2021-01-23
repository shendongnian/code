    public struct Point
    {
    	public double X,Y;
    	
    	public Point(double x, double y)
    	{
    		this.X = x;
    		this.Y = y;
    	}
    }
    
    List<Point> parkedCars = new List<Point>();
    Random random = new Random();
    
    void Main()
    {
    	int parked = 0;
    
    	for (int i = 0; i < 12000; i++)
    	{
    		double x = random.NextDouble() * 100;
    		double y = random.NextDouble() * 100;
    		
    		Point pointToPark = new Point(x, y);
    		
    		if (IsSafeToPark(pointToPark))
    		{
    			parkedCars.Add(pointToPark);
    			parked++;
    		}
    
    	}
    		
    	Console.WriteLine("Parked: " + parked);
    }
    
    private bool IsSafeToPark(Point pointToPark)
    {
    	if (parkedCars.Any(p => Distance(pointToPark, p) <= 1))
    		return false;
    
    	return true;
    }
    
    private double Distance(Point p1, Point p2)
    {
    	return Math.Max(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
    }
