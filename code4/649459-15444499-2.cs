    public class BaseTypeList : List<BaseType>
    {
        public void Add(Type t, string x, string y, string z)
        {
            Add((BaseType)Activator.CreateInstance(t, x, y, z));
        }
    }
