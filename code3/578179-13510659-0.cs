    public class Map
    {
        public string[,] mapTerr = new string[10, 10] {
        { // array contents here
        };
    }
    
    public class UserControl
    {
        int x, y;
        string navDir;
        Map myMap = new Map();
    
        public UserControl()
        {
            Console.WriteLine("Enter a command:");
            navDir = Console.ReadLine();
            switch (navDir)
            {
                case "N":
                case "n":
                    x -= 1;
                    if (myMap.mapTerr[x, y] == "F")
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
