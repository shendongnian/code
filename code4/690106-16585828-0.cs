    private Dictionary<string, object> _internalData = new Dictionary<string, object>();
    public T this[string propName]
    {
        get {
            return _internalData[propName];
        }
        set {
            _internalData[propName] = value;
        }
    }
