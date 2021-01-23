    public class Stat
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
    }
    public class CurrentStat : Stat
    {
        public bool IsCaptain { get; set; }
    }
    public class SeasonStat
    {
        public int MatchesPlayed { get; set; }
    }
    public class CareerStat : Stat
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
        public CurrentStat CurrentStats { get; set; }
        public SeasonStat SeasonStats { get; set; }
        public CareerStat CareerStats { get; set; }
    }
