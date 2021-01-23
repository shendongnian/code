    public class Tank
    {
    	private Rectangle _location;
    	
    	public int X { get { return _location.X; } }
    	public int Y { get { return _location.Y; } }
    	
    	public Tank(int width, int height /* other params */)
    	{
    		_location = new Rectangle(0, 0, width, height);
    	}
    	
    	public Tank Move(Point offset)
    	{
    		_location.X += offset.X;
    		_location.Y += offset.Y;
    		
    		return this;
    	}
    }
