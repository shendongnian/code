    public interface IDummy<TType> where TType : new()
    {
    }
    
    public class Dummy<TType> : IDummy<TType> where TType : new()
    {
    }
