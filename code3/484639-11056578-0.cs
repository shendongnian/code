    public abstract class Game
    {
        
    }
    public class Poker : Game
    {
        private Lobby lobby = new Lobby();
        
        public int MaxPlayers         
        { 
            get
            {           
               int count = lobby.tableList.Sum(t => t.playerList.Sum(c => t.playerList.Count));
               return count;
            }                 
        }
    
    public class Lobby
    {
        public List<Table> tableList { get; set; }
    }
    public class Table
    {
        public List<Player> playerList { get; set; }
    }
    public class Player
    {
        
    }
