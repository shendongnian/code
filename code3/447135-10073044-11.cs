    public class Team<TPlayer> : ITeam<TPlayer>
        where TPlayer : IAthlete
    {
        private readonly List<TPlayer> _players = new List<TPlayer>();
    
        public Team(string name, int teamSize)
        {
            Name = name;
            TeamSize = teamSize;            
        }
    
        public void AddPlayer(TPlayer player)
        {
            if (_players.Count == TeamSize)
                throw new Exception("Players number exceeded");
    
            _players.Add(player);
        }
    
        public string Name { get; private set; }
        public int TeamSize { get; private set; }
    
        public IEnumerable<TPlayer> Players
        {
            get { return _players; }
        }
            
        public int NumberOfPlayers 
        {
            get { return _players.Count; }
        }       
    }
