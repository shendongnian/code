    public Plugin FindDbPlugin(object pluginOnDisk) {        
        Type found = pluginOnDisk.GetType().GetInterfaces().FirstOrDefault(t => knownTypes.ContainsKey(t));
        if (found != null) {
            return (Plugin) Activator.CreateInstance(knownTypes[found]);
        }
        throw new InvalidOperationException("Type is not a Plugin.");
    }
