    /// ======================================================================================
    /// <summary>
    /// Refreshes the settings from disk and returns the specific setting so guarantees the
    /// value is up to date at the expense of disk I/O.
    /// </summary>
    /// <param name="key">The setting key to return.</param>
    /// <remarks>This method does involve disk I/O so should not be used in loops etc.</remarks>
    /// <returns>The setting value or an empty string if not found.</returns>
    /// ======================================================================================
    private string RefreshFromDiskAndGetSetting(string key)
    {
        // Always read from the disk to get the latest setting, this will add some overhead but
        // because this is done so infrequently it shouldn't cause any real performance issues
        ConfigurationManager.RefreshSection("appSettings");
        return GetCachedSetting(key);
    }
    /// ======================================================================================
    /// <summary>
    /// Retrieves the setting from cache so CANNOT guarantees the value is up to date but
    /// does not involve disk I/O so can be called frequently.
    /// </summary>
    /// <param name="key">The setting key to return.</param>
    /// <remarks>This method cannot guarantee the setting is up to date.</remarks>
    /// <returns>The setting value or an empty string if not found.</returns>
    /// ======================================================================================
    private string GetCachedSetting(string key)
    {
        return ConfigurationManager.AppSettings.Get(key) ?? string.Empty;
    }
