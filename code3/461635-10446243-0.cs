    public T ConvertByGenerics<T>(string value, T defaultValue)
    {
       if (!string.IsNullOrEmpty(value))
       {
          return (T)Convert.ChangeType(value, typeof(T));
       }
       return defaultValue;
    }
