    public class DependentParameter<T> : IDependentParameter where T : IValue
    {
       public DependentParameter(T value)
       {
          Value = value;
       }
    
       public T Value;
    
       public object Something;
    }
