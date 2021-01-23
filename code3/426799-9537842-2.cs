    public class PropertyUpdater
    {
        public static PropertyUpdater<T> Update<T>(T objectToUpdate)
        {
            return PropertyUpdater<T>.Update(objectToUpdate);
        }
    }
    public class PropertyUpdater<T>
    {
        private readonly T destination;
        private PropertyUpdater(T destination)
        {
            this.destination = destination;
        }
        public static PropertyUpdater<T> Update(T objectToUpdate)
        {
            return new PropertyUpdater<T>(objectToUpdate);
        }
        public void With(T objectToCopyFrom)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                // Only copy properties with public get and set methods
                if (!p.CanRead || !p.CanWrite || p.GetGetMethod(false) == null || p.GetSetMethod(false) == null) continue;
                // Skip indexers
                if (p.GetGetMethod(false).GetParameters().Length > 0) continue;
                p.SetValue(this.destination, p.GetValue(objectToCopyFrom, null), null);
            }
        }
    }
