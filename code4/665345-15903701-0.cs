    public class MyGenericClass<T> : IDisposable
        where T : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
