    public static Metadata GetMetadata(
        string metadataLoaderApplicationBase,
        string metadataLoaderAssemblyName,
        string sharedDllAssemblyName,
        string metadataSourcePath
    )
    {
        AppDomainSetup domainSetup = new AppDomainSetup();
        domainSetup.ApplicationBase = Path.GetDirectoryName(assemblyName);
        Evidence evidence = AppDomain.CurrentDomain.Evidence;
        AppDomainnewDomain = AppDomain.CreateDomain("AppDomain Friendly Name",
            evidence,
            domainSetup);
    
        MetadataSourceWrapper msw =
            (MetadataSourceWrapper)newDomain.CreateInstanceAndUnwrap(sharedDllAssemblyName,
                "YourNamespace.MetadataSourceWrapper" /*full type name including the namespace*/);
        msw.Load(metadataSourcePath);
        IMetadataLoader metadataLoader =
            (IMetadataLoader)newDomain.CreateInstanceAndUnwrap(metadataLoaderAssemblyName,
                "YourNamespace.MetadataLoader" /*full type name including the namespace*/);
        metadataLoader.Init(msw);
        Metadata metadata = metadataLoader.Metadata;
        AppDomain.Unload(newDomain);
        return metadata;
    }
