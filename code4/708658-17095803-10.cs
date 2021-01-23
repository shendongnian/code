    public class PlayerStat //Add 'Player' to name since stats can be for tourneys too
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
    }
    public class PlayerCurrentMatchStat : PlayerStat 
    {
        public bool IsCaptain { get; set; }
    }
    public class PlayerSeasonStat : PlayerStat 
    {
        public int MatchesPlayed { get; set; }
    }
    public class PlayerCareerStat : PlayerStat 
    {
    }
    //And your football player goes like this:
    class FootballPlayer
    {
        public FootballPlay()
        {
            CurrentStats = new CurrentStat();
            SeasonStats = new SeasonStat();
            CareerStats = new CareerStat();
        }
    
        public string Name { get; set; }
        public string TeamName { get; set; }   
        public PlayerCurrentMatchStat CurrentMatchStat { get; set; }
        public PlayerSeasonStat  SeasonStat { get; set; } //no need of naming 'Player' 
        public PlayerCareerStat CareerStat { get; set; }  //inside Player class
    }
