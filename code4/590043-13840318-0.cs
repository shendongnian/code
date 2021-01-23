    <section name="cachingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Caching.Configuration.CacheManagerSettings, Microsoft.Practices.EnterpriseLibrary.Caching" requirePermission="true" />
    ...
    <cachingConfiguration defaultCacheManager="Default">
      <cacheManagers>
        <add name="Default" expirationPollFrequencyInSeconds="60" maximumElementsInCacheBeforeScavenging="10000" numberToRemoveWhenScavenging="100" backingStoreName="NullBackingStore" type="Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager, Microsoft.Practices.EnterpriseLibrary.Caching" />
      </cacheManagers>
      <backingStores>
        <add type="Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.NullBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching" name="NullBackingStore" />
      </backingStores>
    </cachingConfiguration>
