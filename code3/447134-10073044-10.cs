    public interface ITeam<TPlayer>
        where TPlayer : IAthlete
    {
        void AddPlayer(TPlayer player);
        IEnumerable<TPlayer> Players { get; }
        string Name { get; }
        int NumberOfPlayers { get; }
    }
