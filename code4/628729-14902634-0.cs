    [XmlRoot("root")]
    public class Team
    {
        private List<Player> players = new List<Player>();
    
        [XmlElement("player")]
        public List<Player> Players { get { return this.players; } set { this.players = value; } }
    
        // serializer requires a parameterless constructor class
        public Team() { }
    }
            
    public class Player
    {
        private List<int> verticalLeaps = new List<int>();
    
        [XmlElement]
        public string FirstName { get; set; }
        [XmlElement]
        public string LastName { get; set; }
        [XmlElement]
        public List<int> vertLeap { get { return this.verticalLeaps; } set { this.verticalLeaps = value; } }
    
        // serializer requires a parameterless constructor class
        public Player() { }
    }
