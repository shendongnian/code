    List<object> callbacks = new List<object>();
    public void AddCallback<T1>(object type, Action<T1> callback)
    {
        this.callbacks.Add(callback);
    }
    public IEnumerable<Action<T>> GetCallbacks<T>()
    {
        return this.callbacks.OfType<Action<T>>();
    }
