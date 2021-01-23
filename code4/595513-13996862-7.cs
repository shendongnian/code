    public static Metadata GetMetadata(
        string metadataLoaderApplicationBase, /*e.g. `C:\MyCompany\MyApp*`*/
        string metadataLoaderAssemblyName, /*e.g. `MetadataLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null` or `MetadataLoader`*/
        string sharedDllAssemblyName, /*e.g. `Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null` or `Shared`*/
        string metadataSourcePath
    )
    {
        AppDomainSetup domainSetup = new AppDomainSetup();
        domainSetup.ApplicationBase = Path.GetDirectoryName(assemblyName);
        Evidence evidence = AppDomain.CurrentDomain.Evidence;
        AppDomain newDomain = AppDomain.CreateDomain("AppDomain Friendly Name",
            evidence, domainSetup);
    
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
