    private static IStorageProvider BAWP8StorageProvider
    {
        get
        {
            GetProvider(BLL.Providers.ConfigurationProvider.Instance.BAWP8StorageProviderTypeName, ref _BAWP8storageProvider);
            return _BAWP8StorageProvider;
        }
    }
