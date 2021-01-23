    public class Player : IAthlete
    {
        public Player(string name, string sport)
        {
            Name = name;
            Sport = sport;
        }
    
        public string Name { get; private set; }
        public string Sport { get; private set; }        
    }
