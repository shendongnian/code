    public class CollisionResult
    {
    	public Circle Circle1 { get; private set; }
    	public Circle Circle2 { get; private set; }
    	
    	public Point Circle1SafeLocation { get; private set; }
    	public Point Circle2SafeLocation { get; private set; }
    
    	public Point CollisionLocation { get; private set; }
    	
    	public CollisionResult(Circle circle1, Circle circle2)
    	{
    		this.Circle1 = circle1;
    		this.Circle2 = circle2;
    	}
    	
    	public bool CalculateCollision()
    	{
    		double distanceFromCentres = Circle1.Position.Distance(Circle2.Position);
    		if (distanceFromCentres >= Circle1.Radius + Circle2.Radius)
    			return false;
    			
    		double angleBetweenCircles = System.Math.Atan2(Circle2.Position.Y - Circle1.Position.Y, Circle2.Position.X - Circle1.Position.X);
    		
    		Point midpointBetweenCircles = new Point(){X = (Circle1.Position.X + Circle2.Position.X)/2, Y = (Circle1.Position.Y + Circle2.Position.Y)/2};
    		
    		Point circle1Offset = (new Polar() { Radius = Circle1.Radius, Angle = System.Math.PI + angleBetweenCircles }).ToCartesian();
    		Point circle2Offset = (new Polar() { Radius = Circle2.Radius, Angle = angleBetweenCircles }).ToCartesian();
    		
    		CollisionLocation = midpointBetweenCircles;
    		Circle1SafeLocation = new Point(){X = midpointBetweenCircles.X + circle1Offset.X, Y = midpointBetweenCircles.Y + circle1Offset.Y };
    		Circle2SafeLocation = new Point(){X = midpointBetweenCircles.X + circle2Offset.X, Y = midpointBetweenCircles.Y + circle2Offset.Y };
    		
    		return true;
    	}
    }
