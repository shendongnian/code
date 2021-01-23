    [ImportMany]
    private IEnumerable<Lazy<IExtension, IExtensionMetadata>> operations;
    public void ExecuteExtensions()
    {
        // ...
    
        foreach(Lazy(IExtension, IExtensionMetadata> extension in operations) 
        {
            IExtension decoratedExtension = DecorateExtension(extension);
            result.Add(decoratedExtension, decoratedExtension.Execute()); 
        }
    }
    private IExtension DecorateExtension(Lazy<IExtension, IExtensionMetadata> exportedExtension)
    {
        IExtension ext = exportedExtension.Value;
        if (exportedExtension.Metadata.IsBatch)
        {
            ext = new BatchableExtension(ext);
        }
        if (exportedExtension.Metadata.IsMonitoring)
        {
            ext = new MonitoringExtension(ext);
        }
        // Other decorating logic...
        return ext;
    }
