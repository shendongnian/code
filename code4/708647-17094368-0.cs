    class FootballPlayer
    {
        public FootballPlay()
        {
            CareerStats = new StatDetails();
            SeasonStats = new StatDetails();
            CurrentStats = new StatDetails();
        }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public StatDetails CareerStats { get; set; }
        public StatDetails SeasonStats { get; set; }
        public StatDetails CurrentStats { get; set; }
    }
    class StatDetails
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Passes { get; set; }
    }
