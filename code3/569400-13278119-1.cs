    public class MyTypeList
    {
        List<Type> _innerList;
        public void Add(Type type)
        {
            if (typeof(IBase).IsAssignableFrom(type)) {
                 _innerList.Add(type);
            } else {
                throw new ArgumentException(
                    "Type must be IBase, implement or derive from it.");
            }
        }
        ...
    }
