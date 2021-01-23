    public interface ITerm
    {
        string Name { get; }
    }
    public class Value : ITerm...
    
    public class Variable : ITerm...
    public class Query
    {
       public IList<ITerm> Terms { get; }
    ...
    }
