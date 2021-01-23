       private static IStorageProvider BAStorageProvider
    {
        get
        {
            GetProvider(BLL.Providers.ConfigurationProvider.Instance.BAStorageProviderTypeName, ref _BAWP8storageProvider);
            return _BAWP8StorageProvider;
        }
    }
