    public class SimpleInstantiator<T> where T : new()
    {
        private T instance;
        private IDictionary<string, PropertyInfo> properties;
                    
        public SimpleInstantiator()
        {
            Type type = typeof(T);
            properties = type.GetProperties()
                             .GroupBy(p => p.Name)
                             .ToDictionary(g => g.Key, g => g.ToList().First());
        }
            
        public void CreateNewInstance()
        {
            instance = new T();
        }
        
        public void SetValue(string pPropertyName, object pValue)
        {
            if (pPropertyName == null) return;
            
            PropertyInfo property;
            if (!properties.TryGetValue(pPropertyName, out property)) return;
            
            property.SetValue(instance, pValue, null);
        }
        
        public T GetInstance()
        {
            return instance;
        }
    }
