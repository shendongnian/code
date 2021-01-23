    public interface IHandler
    {
        void Handle();
    }
    
    public sealed class HandlerFactory
    {
        private readonly Dictionary<string, Type> _map = new Dictionary<string, Type>();
    
        public HandlerFactory()
        {
            var handlers = (NameValueCollection)ConfigurationManager.GetSection("Handlers");
            if (handlers == null)
                throw new ConfigurationException("Handlers section was not found.");
            foreach (var key in handlers.AllKeys)
            {
                var typeName = handlers[key] ?? string.Empty;
                // the type name must be qualified enough to be 
                // found in the current context.
                var type = Type.GetType(typeName, false, true);
                if (type == null)
                    throw new ConfigurationException("The type '" + typeName + "' could not be found.");
                if (!typeof(IHandler).IsAssignableFrom(type))
                    throw new ConfigurationException("The type '" + typeName + "' does not implement IHandler.");
                _map.Add(key.Trim().ToLower(), type);
            }
        }
    
        // Allowing your factory to construct the value 
        // means you don't have to write construction code in a million places.
        // Your current implementation is a glorified dictionary
        public IHandler Create(string key)
        {
            key = (key ?? string.Empty).Trim().ToLower();
            if (key.Length == 0)
                throw new ArgumentException("Cannot be null or empty or white space.", "key");
            Type type;
            if (!_map.TryGetValue(key, out type))
                throw new ArgumentException("No IHandler type maps to '" + key + "'.", "key");
            return (IHandler)Activator.CreateInstance(type);
        }
    }
