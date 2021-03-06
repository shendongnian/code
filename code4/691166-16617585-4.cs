    [XmlRoot("PlayerStats")]
    public class PlayerStats
    {
        [XmlElement(ElementName = "Player")]
        public List<Player> Players { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
        public int WinCount { get; set; }
        public int PlayCount { get; set; }
    }
