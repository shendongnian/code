    public class Tournament
    {
     public List<Round> Rounds { get; set; }
     public List<Team> Teams { get; set; }
    }
    public class Team
    {
     public List<Player> Players { get; set; }
    }
    public class Round
    {
     public Team Home { get; set; }
     public Team Away { get; set; }
    }
    public class Player
    {
     public string Name { get; set; }
    }
