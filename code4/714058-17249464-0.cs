    private IDictionary<string,object> _settings = new Dictionary<string,object>();
    public void AddSetting<T>(string key, T value) {
        _settings[key] = value;
    }
    public T GetSetting<T>(string key, T notFound = default(T)) {
        object res;
        if (!_settings.TryGetValue(key, out res) || !(res is T)) {
            return notFound;
        }
        return (T)res;
    }
