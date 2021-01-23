    class Team<TPlayer> where TPlayer : IAthlete {
        public ReadOnlyCollection<TPlayer> Players { get; }
        public string Name { get; }
        public void AddPlayer(TPlayer player);
    }
