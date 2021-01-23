    public interface IActionWrapper
    {
    
        bool AcceptsParameterType(Type t);
        void PerformAction(object o);
    }
    
    public class ActionWrapper<T> : IActionWrapper
    {
        Action<T> yourAction {get;set;}
        
        public bool AcceptsParameterType(Type t)
    {
    return t is T;
    }
    
    public void PerformAction(object o)
    {
      yourAction((T)o);
    }
    
    }
