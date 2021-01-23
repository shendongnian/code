    private static ConcurrentDictionary<string, ISettings> _settingsDictionary = new ConcurrentDictionary<string, ISettings>();
    public T Settings<T>() where T : ISettings, new() {
        var key = typeof(T).FullName;
    
        return _settingsDictionary.GetOrAdd(key, _settingsService.GetSettings<T>());
    }
