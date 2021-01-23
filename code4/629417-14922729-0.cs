    public T Convert<T>(T value)
    {
        Type type = typeof(T);
        if(type.IsEnum)
            return (T)Enum.Parse(type, value , true);
        } else {
            ...
        }
    }
