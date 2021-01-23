    public class CageableTypesCollection : 
    {
        private List<Type> _cageableTypes;
        
        public CageableTypesCollection()
        {
           _cageableTypes = new List<Type>();
        }
        public RegisterType(Type t)
        {
           if (!typeof(ICageable).IsAssignableFrom(t))
              throw new ArgumentException("wrong type of type");
           _cageableTypes.Add(t);
        }
        public UnregisterType(Type t)
        {
           ....
        }
        .....
    }
