    public class Team<TPlayer> : ITeam<TPlayer>
        where TPlayer : IAthlete
    {
        private readonly List<TPlayer> _players = new List<TPlayer>();
    
        public Team(string name, int maxNumberOfPlayers)
        {
            Name = name;
            MaxNumberOfPlayers = maxNumberOfPlayers;            
        }
    
        public void AddPlayer(TPlayer player)
        {
            if (_players.Count == MaxNumberOfPlayers)
                throw new Exception("Players number exceeded");
    
            _players.Add(player);
        }
    
        public string Name { get; private set; }
        public int MaxNumberOfPlayers { get; set; }
    
        public IEnumerable<TPlayer> Players
        {
            get { return _players; }
        }
            
        public int NumberOfPlayers 
        {
            get { return _players.Count; }
        }       
    }
