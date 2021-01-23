    public static class MyUtilities
    {
        public static bool DoUpdate<T>(
            this T target, T source) where T: class
        {
            if(target == null) throw new ArgumentNullException("target");
            if(source == null) throw new ArgumentNullException("source");
            
            if(ReferenceEquals(target, source)) return false;
            var props = typeof(T).GetProperties(
                BindingFlags.Public | BindingFlags.Instance);
            bool result = false;
            foreach (var prop in props)
            {
                if (!prop.CanRead || !prop.CanWrite) continue;
                if (prop.GetIndexParameters().Length != 0) continue;
    
                object oldValue = prop.GetValue(target, null),
                       newValue = prop.GetValue(source, null);
                if (!object.Equals(oldValue, newValue))
                {
                    prop.SetValue(target, newValue, null);
                    result = true;
                }
            }
            return result;
        }
    }
