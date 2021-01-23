    public class clsA<T, T1>
        where T : clsB<T1>, new()
        where T1 : class
    {
        public T GetEntity()
        {
            return new T();
        }
    }
