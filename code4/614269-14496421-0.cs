    public static Position Location(int p_1, int p_2, int p_3, int p_4)
    {
		
	Position location;
	location.xLocation = p_2 - p_1;
	location.yLocation =p_4-p_3;;
	return location;
    }
    
    public struct Position
    {
	public int xLocation;
	public int yLocation;
    }
