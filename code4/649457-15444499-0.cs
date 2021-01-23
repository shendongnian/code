    public class BaseTypeList : List<BaseType>
    {
        public void Add(string x, string y, string z)
        {
            Add(new DerivedType { x = x, y = y, z = z });
        }
    }
