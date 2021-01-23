	using System;
	public struct Point
	{
	   public int x, y;
	   public Point(int p1, int p2)
	   {
	      x = p1;
	      y = p2;
	   }
	}
	public struct Information
	{
	   public string description, location;
	   public Information(string desc, string loc)
	   {
	      description = desc;
	      location = loc;
	   }
	}
	var info = new Dictionary<Point, Information>();
	info[Point(i,j)] = Information("This is our lovely lake","Lake");
