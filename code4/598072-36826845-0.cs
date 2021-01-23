    public class TypeDict
    {
        public T Get<T>() where T : class
        {
            T value;
            InnerDict<T>.Values.TryGetValue(this, out value);
            return value;
        }
        public void Set<T>(T value) where T : class
        {
            var cwt = InnerDict<T>.Values;
            // lock+remove+add https://github.com/dotnet/coreclr/issues/4545
            lock (cwt)
            {
                cwt.Remove(this);
                cwt.Add(this, value);
            }
        }
        private static class InnerDict<T> where T : class
        {
            public static ConditionalWeakTable<TypeDict, T> Values { get; private set; }
            static InnerDict()
            {
                Values = new ConditionalWeakTable<TypeDict, T>();
            }
        }
    }
