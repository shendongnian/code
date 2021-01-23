    public interface IWrapper<out T>
    {
        T Value {get;}
        string Description;
    }
    
    public class ClassA<T> : IWrapper<T>
    {
        //...
    }
    
    public void DoWork(IWrapper<object> source, IWrapper<object> destination)
    {
      destination.Description = source.Description;
    }
