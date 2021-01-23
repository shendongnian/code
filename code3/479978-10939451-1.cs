    public interface IGameFactory
    {
        IEnumerable<Game> GetGames();
        Game GetGame(string name);
    }
