    private bool HasPropertyChanged<T>(T Original, T Modified, string[] IgnoreProperties)
    {
        return HasPropertyChanged(typeof(T), Original, Modified, IgnoreProperties);
    }
    private bool HasPropertyChanged(Type T, object Original, object Modified, string[] IgnoreProperties)
    {
        // ...
    }
