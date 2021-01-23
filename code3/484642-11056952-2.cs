    public abstract class Game
    {
        // force all Game descendants to implement the property
        public abstract int MaxPlayers { get; } 
    }
    public class Poker : Game
    {
        // Lobby Object
        public List<Lobby> Lobbies { get; set; }
        // NUMBER OF PLAYERS ( Max )
        // the abstract prop needs to be overridden here
        public override int MaxPlayers 
        { 
           get { return 4; } 
        }
    }   
    
    public class Lobby
    {
        public List<Table> Tables { get; set; }
    }
    public class Table                           
    {                    
        public Game CurrentGame { get; set; }
        public List<Player> Players { get; set; }
        // force the Game instance to be provided as ctor param.
        public Table(Game gameToStart)
        {
            CurrentGame = gameToStart;
        }
    }
