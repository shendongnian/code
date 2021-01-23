    public static class ConfigurationExtensions
    {
        public IEnumerable<T> GetValues<T>(this ConfigurationValue val)
        {
            string value = val.Value;
    
            string[] parts = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
            List<T> convertedTypes = new List<T>();
    
            foreach (string part in parts)
            {
                T converted = (T)Convert.ChangeType(part.Trim(), typeof(T));
                convertedTypes.Add(converted);
            }
    
            return convertedTypes;
        }
    }
