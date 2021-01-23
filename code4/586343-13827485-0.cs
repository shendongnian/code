    <subclass name="Foo" discriminator-value="MoveFile">
      <property name="SerialisedProps" column="serialisedProps" access="Name.Space.FakeAccessor, Asse" />
    </subclass>
    class FakeAccessor : IPropertyAccessor, IGetter, ISetter
    {
        public IGetter GetGetter(string name)
        {
            return this;
        }
    
        public ISetter GetSetter(string name)
        {
            return this;
        }
    
        public bool CanAccessThroughReflectionOptimizer { get { return false; } }
    
        public object Get(object target)
        {
            return Serialize(target);
        }
        object GetForInsert(object owner, IDictionary mergeMap, ISessionImplementor session)
        {
            return Get(owner);
        }
    
        public void Set(object target, object value)
        {
            // deserialize xml and set appropriate properties
        }
    
        Type ReturnType { get { return typeof(string); } }
    
        string PropertyName { get { return "SerialisedProps"; } }
    
        private string Serialize(object subclass)
        {
            // example implementation
            var type = subclass.GetType();
            var root = new XElement(type.Name);
            foreach (var prop in type.GetProperties())
            {
                root.Add(new XElement("property", new XAttribute("name", prop.name), new XAttribute("value", prop.GetValue(subclass, null) + ""));
            }
            return root.ToString();
        }
    }
