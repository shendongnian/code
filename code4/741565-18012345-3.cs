    public interface IStateManager
    {
        T GetItem<T>(string key);
        SetItem<T>(string key, T value);
    }
