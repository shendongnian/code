    private static IDictionary<string, ISettings> _settingsDictionary = new Dictionary<string, ISettings>();
    private static object locker = new object();
    
    public T Settings<T>() where T : ISettings, new() {
        var key = typeof(T).FullName;
        lock(locker) 
        {
            if (!_settingsDictionary.ContainsKey(key))
                _settingsDictionary[key] = _settingsService.GetSettings<T>();
    
            return (T)_settingsDictionary[key];
        }
    }
