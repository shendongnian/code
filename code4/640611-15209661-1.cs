    // Metadata for a type
    public sealed class TypeMetadata<T> {
    
        // The compiled getters for the type; the property name is the key
        public Dictionary<string, Func<T, object>> Getters {
            get;
            set;
        }
    
        // The compiled setters for the type; the property name is the key
        public Dictionary<string, Action<T, object>> Setters {
            get;
            set;
        }
    }
    // rough invocation flow
    var type = typeof( T);
    var metadata = _cache[type];
    var propertyName = "MyProperty";
    var setter = metadata[propertyName];
    var instance = new T();
    var value = 12345;
    setter( instance, value );
