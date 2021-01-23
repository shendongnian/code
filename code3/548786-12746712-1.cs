    public class CagedTypes 
    {
        private readonly List<Type> _types;
        public void Add(Type t)
        {
            if (t == typeof(Hippo) || t == typeof(Tiger))
                _types.Add(t);
        }
    }
