    public interface IRetVal<out T>
    {
        
    }
    public class RetVal<T> : IRetVal<T> where T : MyBase { /* body omitted */ }
    public class Test
    {
        public IRetVal<T> GetRetValT<T>() where T : MyBase
        {
            return null;
        }
    }
