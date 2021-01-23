    public static class Extension<T>
    {
        static public T f_DeepClone<T>(this object obj) where T: ISerializable
        {
            // doing some serialization and deserialization
            return (T) obj;
        }
    }
