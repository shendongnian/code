    using System.Collections;
    using System;
    class Program
    {
        public static void Main(string[] args)
        {
            UserControl usercontrol = new UserControl();
        }
    }
    class Map
    {
	// Private map
	private string[,] mapTerr;
	
	// Public map
	public string[,] MapTerr
	{
		get {return mapTerr;}
	}
	
	public Map(int width, int height)
	{
		mapTerr = new string[width, height];
		
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				mapTerr[x,y] = "E";
			}
		}
	}
    }
    class UserControl
    {
        int x, y;
        string navDir;
	Map map;
        public UserControl()
        {
            map = new Map(10, 10);
            Console.WriteLine("Enter a command:");
            navDir = Console.ReadLine();
            switch (navDir)
            {
                case "N":
                case "n":
                x -= 1;
                if (map.MapTerr[x, y] == "F") // ERROR: The name 'mapTerr' does not exit in the current context"
                {
                    Console.WriteLine("You cannot move North, it is blocked!");
                    x += 1;
                }
                else
                {
                    Console.WriteLine("You move North.");
                }
                break;
            // etc...
            }
	}
    }
