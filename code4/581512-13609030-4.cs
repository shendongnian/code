    public class Statistic
    {
        public Statistic(int id, int homeshot, int homescore, int awayshot, int awayscore)
        {
            ID = id;
            HomeShot = homeshot;
            HomeScore = homescore;
            AwayShot = awayshot;
            AwayScore = awayscore;
        }
        public int ID { get; set; }
        public int HomeShot { get; set; }
        public int HomeScore { get; set; }
        public int AwayShot { get; set; }
        public int AwayScore { get; set; }
    }
