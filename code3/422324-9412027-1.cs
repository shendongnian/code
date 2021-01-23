    string containerName = context.DefaultContainerName;
    string setName = context.CreateObjectSet<X>().EntitySet.Name;
    EntityKey key = new EntityKey(String.Format("{0}.{1}", containerName, setName), 
                                  "KeyProperty", x.KeyProperty);
    if (context.ObjectStataManager.GetObjectStateEntry(key) != null)
    {
        // Apply current values
    }
    else
    {
        // Attach and set state
    }
