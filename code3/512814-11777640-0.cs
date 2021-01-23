    private static IStorageProvider GetProvider(string typeName)
    {
        return (IStorageProvider)Activator.CreateInstance(Type.GetType(typeName));
    }
    private static readonly Lazy<IStorageProvider> _BAstorageProvider =
        new Lazy<IStorageProvider>(
            () => GetProvider(
                BLL.Providers.ConfigurationProvider.Instance.BAStorageProviderTypeName),
            LazyThreadSafetyMode.ExecutionAndPublication);
    private static readonly Lazy<IStorageProvider> _BAWP8storageProvider =
        new Lazy<IStorageProvider>(
            () => GetProvider(
                BLL.Providers.ConfigurationProvider.Instance.BAWP8StorageProviderTypeName),
            LazyThreadSafetyMode.ExecutionAndPublication);
    private static readonly Lazy<IStorageProvider> _M4MstorageProvider =
        new Lazy<IStorageProvider>(
            () => GetProvider(
                BLL.Providers.ConfigurationProvider.Instance.M4MStorageProviderTypeName),
            LazyThreadSafetyMode.ExecutionAndPublication);
    private static IStorageProvider BAStorageProvider
    {
        get
        {
            return _BAstorageProvider.Value;
        }
    }
    private static IStorageProvider BAWP8StorageProvider
    {
        get
        {
            return _BAWP8storageProvider.Value;
        }
    }
    private static IStorageProvider M4MStorageProvider
    {
        get
        {
            return _M4MStorageProvider.Value;
        }
    }
