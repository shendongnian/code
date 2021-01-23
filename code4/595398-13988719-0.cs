    public static class Extension
    {
        static public ISerializable f_DeepClone(this ISerializable obj)
        {
            // doing some serialization and deserialization
            return (T) obj;
        }
    }
