    using System.Reflection;
    public class DefaultObject
    {
        ...
    }
    public class ExtendedObject : DefaultObject
    {
        ....
        public DefaultObject Parent { get; set; }
  
        public ExtendedObject() {}
        public ExtendedObject(DefaultObject parent)
        {
            Parent = parent;
            foreach (PropertyInfo prop in parent.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(parent, null), null);
        }
    }
