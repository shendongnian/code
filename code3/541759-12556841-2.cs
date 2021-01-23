    public Plugin FindDbPlugin<TKey>(TKey pluginOnDisk)
    {
        Type found;
        if (knownTypes.TryGetValue(typeof(TKey), out found) && found != null)
        {
            Plugin value = Activator.CreateInstance(found) as Plugin;
            if (value == null)
            {
                throw new InvalidOperationException("Type is not a Plugin.");
            }
            return value;
        }
    }
