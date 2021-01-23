    public interface IBase {}
    public class Base1 : IBase { public int x; }
    public class Base2 : IBase { public int y; }
    public class Base3 : IBase { public int z; }
    public class MyClass
    {
        Dictionary<Type, IBase> m_typesCollection;
        public MyClass()
        {
            // for example
            m_typesCollection = new Dictionary<Type, IBase>();
            m_typesCollection.Add(typeof(Base1), new Base1());
            m_typesCollection.Add(typeof(Base2), new Base2());
        }
        public IBase GetObject<T>()
            where T : IBase, new()
        {
            if (m_typesCollection.ContainsKey(typeof(T)))
                return m_typesCollection[typeof(T)];
            m_typesCollection.Add(typeof(T), new T());
            return m_typesCollection[typeof(T)];
        }
    }
