    public interface Stat //common interface which can be for tourneys, matches etc too
    {
        int Goals { get; set; }
        int Assists { get; set; }
        int Passes { get; set; }
    }
    //You might want to break this interface further to fit in other specific stats
    //like player stat, match stat etc.
    //Also making it an interface rather than base class is better, you cant have 
    //2 different entities like PlayerStat and MatchStat share a common base class
    public class PlayerStat : Stat //can be career stat, single match stat etc
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
    }
    //another example
    public class MatchStat : Stat 
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
        public int Viewership { get; set; }
    }
    
    class Team
    {
        // all what makes a good unit
    }    
    
    class Match
    {
        public Team Team1 { get; set; } 
        public Team Team2 { get; set; } 
        public double TimeElapsed { get; set; }   
        public string RefereeName { get; set; } 
        public MatchStat MatchStat { get; set; } //a match has match stat
    }
    
    //provide a suitable constructor that takes a player and a match
    public class PlayerMatchStat
    {
        public Player Player { get; set; }
        public Match Match { get; set; }
        public PlayerStat Stat { get; set; } //should return player's stat for this match
        public bool IsCaptain { get; set; }
        public int DistanceCompleted { get; set; }
    }
    //provide a suitable constructor that takes a player and a season
    public class PlayerSeasonStat
    {   
        public bool Player { get; set; }
        public Season Season { get; set; } //have a season class
        public PlayerStat Stat { get; set; } //should return player's stat for this season
        public int RedCards { get; set; }
    }
    //and lastly
    class Player
    {
        public Player()
        {
            //init work
        }
    
        public string Name { get; set; } 
        public PlayerStat CareerStat { get; set; } //just like match has match stat
        public Team[] Teams { get; set; } //Team name shouldn't go within a player 
                                          //class, he could be in many teams.
        //since player inherently has no match or season, we shall provide methods to query them
        public PlayerMatchStat GetMatchStat(Match match)
        {
            return new PlayerMatchStat(match, this);
        }
        public PlayerSeasonStat GetSeasonStat(Season season)
        {
            return new PlayerSeasonStat(season, this);
        }
    }
