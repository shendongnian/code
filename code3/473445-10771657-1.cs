    private Configuration readConfigFromCacheFileOrBuildIt()
    {
        Configuration nhConfigurationCache;
        var nhCfgCache = new ConfigurationFileCache(MappingsAssembly);
        var cachedCfg = nhCfgCache.LoadConfigurationFromFile();
        if (cachedCfg == null)
        {
            nhConfigurationCache = buildConfiguration();
            nhCfgCache.SaveConfigurationToFile(nhConfigurationCache);
        }
        else
        {
            nhConfigurationCache = cachedCfg;
        }
        return nhConfigurationCache;
    }
