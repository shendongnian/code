    static public T f_DeepClone<T>(this object obj)
    {
        if(typeof(T).IsSerializable == false)
            throw new ArgumentException("Cannot clone non-serializable objects");
        // doing some serialization and deserialization
        return (T) obj;
    }
