    public static class XAttributeExtensions
    {
        public T GetValueOrDefault<T>(this IXAttribute attr)
        {        
            var typedAttr = attr as IXAttribute<T>;
            if (typedAttr == null) {
                return default(T);
            }
            return typedAttr.Value;
        }
    }
