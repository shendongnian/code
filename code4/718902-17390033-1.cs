    public class Server
    {
        public string serverName { get; set; }
        public string dnsIP { get; set; }
        public Game game { get; set; }
    }
    public class Game
    {
        public enum Genre { FPS, RTS, RPG, MMO, MOBA, TPS, Sandbox, Other };
        public string gameName { get; set; }        
        public Genre genre { get; set; }
    }
