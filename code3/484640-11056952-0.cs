    public abstract class Game
    {
    }
    public class Poker : Game
    {
        // Lobby Object
        public List<Lobby> Lobbies { get; set; }
        // NUMBER OF PLAYERS ( Max )
        public int MaxPlayers { get; set; }
    }   
    
    public class Lobby
    {
        public List<Table> Tables { get; set; }
    }
    public class Table                           
    {                                            
        public List<Player> Players { get; set; }
    }
