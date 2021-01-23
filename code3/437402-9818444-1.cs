    public class TypeValidator<T>
    {
        public bool IsPropertyExists(string propertyName)
        {
            Type type = typeof(T);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            foreach (PropertyInfo property in type.GetProperties(flags))
                if (property.Name == propertyName)
                    return true;
    
            return false;
        }
    }
