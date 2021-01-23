    public static IEnumerable<T> GetCustomAttributes(
        this ICustomAttributeProvider provider, bool inherit) where T : Attribute
    {
        // Validate parameters.
        if (provider == null) throw new ArgumentNullException("provider");
    
        // Get custom attributes.
        return provider.GetCustomAttributes(typeof(T), inherit).
            Cast<T>();
    }
