    public class PropertyMap<T>
    {
        readonly T Instance;
        public PropertyMap(T instance)
        {
            Instance = instance;
        }
        
        public U Get<U>(string PropertyName)
        {
            // Search through the type's properties for one with this name
            PropertyInfo property = typeof(T).GetProperty(PropertyName);
            if (property == null)
            {
                // if we couldn't find a property, look for a field.
                FieldInfo field = typeof(T).GetField(PropertyName);
                if (field == null)
                    throw new Exception("Couldn't find a property/field named " + PropertyName);
                return (U)field.GetValue(Instance);
            }
            return (U)property.GetValue(Instance, null);
        }
        public void Set<U>(string PropertyName, U value)
        {
            // Search through the type's properties for one with this name
            PropertyInfo property = typeof(T).GetProperty(PropertyName);
            if (property == null)
            {
                // if we couldn't find a property, look for a field.
                FieldInfo field = typeof(T).GetField(PropertyName);
                if (field == null)
                    throw new Exception("Couldn't find a property/field named " + PropertyName);
                field.SetValue(Instance, value);
                return;
            }
            property.SetValue(Instance, value, null);
        }
    }
