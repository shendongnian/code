    public interface IGame
    {
       string Name {get;}
       ...
    }
    
    public class Bastketball : IGame
    {
       ...
    }
    
    public interface ITeam<TGame> where TGame: class, IGame
    {
       void AddPlayer(IPlayr<TGame> player);
       ...
    }
    
    
    public interface IPlayer<TGame> where TGame: class, IGame
    {
       ...
       
    }
