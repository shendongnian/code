    public class Player
    {
        public static Player CurrentPlayer = new Player(); // This is your global instance
        public string name;
        // All of your other content here
    }
    public class Program
    {
        public static void Main()
        {
            // In here we can access our global instance of `Player` to change it as needed
            Player.CurrentPlayer.name = "Some Name Here";
        }
    }
