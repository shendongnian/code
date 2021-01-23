    private List<Player> players;
    [XmlElement("Player")]
    public List<Player> Players {
        get { return players ?? (players = new List<Player>()); }
    }
