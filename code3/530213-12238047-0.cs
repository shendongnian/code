    public interface IDisplayable
    {
        int Id {get; }
        string Name { get; }
        string Description { get; }
    }
    
    public class Car : IDisplayable
    {
        ...
    }
