    public interface IM
    {
    }
    public class M : IM
    {
    }
    public class N : IM
    {
    }
    public class SomeGenericClass 
    {
        public T GetData<T>(T instance) where T : IM
        {
            return instance;
        }
    }
