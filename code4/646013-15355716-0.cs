    public class Player
    {
        // For access
        public static IEnumerable<Player> Players { get; private set; }
        public int Id { get; private set; }
        // Private constructor
        private Player(int Id)
        {
            this.Id = Id;
        }
        // Factory method
        public static void CreatePlayers(int NumPlayers)
        {
            // Only create players collection once!
            if (Players != null)
                throw new InvalidOperationException();
 
            Players = new List<Player>(NumPlayers);
            for (int i = 0; i < NumPlayers; i++)
            {
                var player = new Player(i);
                player.Players = Players;
                Players.Add(player);
            }
        }
        public void DoStuff()
        {
            // ...
        }
    }
