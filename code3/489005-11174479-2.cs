    public class InitializableKVPs<T1,T2> : IEnumerable<KeyValuePair<T1,T2>>
    {
        public void Add(T1 key, T2 value) 
        {
            throw new NotImplementedException();
        }
        public IEnumerator<KeyValuePair<string,string>>  GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator  IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
