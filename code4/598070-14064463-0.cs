    public class TypeDict
    {
        public T Get<T>()
        {
            return MyDict<T>.Values[this];
        }
        public void Set<T>(T value)
        {
            MyDict<T>.Values[this] = value;
        }
        private static class MyDict<T>
        {
            public static Dictionary<TypeDict, T> Values { get; private set; }
            static MyDict()
            {
                Values = new Dictionary<TypeDict, T>();
            }
        }
    }
