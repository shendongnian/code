    Configuration config;
    ISessionFactory factory;
    public object DeepClone(object original)
    {
        var metadata = factory.GetClassMetadata(original.GetType());
        var clone = metadata.Instantiate(0 /*or extract unsaved value from config*/, EntityMode.Poco);
        var values = metadata.GetPropertyValues(original, EntityMode.Poco);
        for (int i = 0; i < metadata.PropertyTypes.Length; i++)
        {
            if (metadata.PropertyTypes[i].IsAssociationType && values[i] != null)
            {
                values[i] = DeepClone(values[i]);
            }
            if (metadata.PropertyTypes[i].IsCollectionType)
            {
                // TODO: Copy Collection
            }
        }
        metadata.SetPropertyValues(clone, values, EntityMode.Poco);
        return clone;
    }
