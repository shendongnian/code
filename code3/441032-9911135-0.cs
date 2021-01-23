    public static bool SerializeObject<T>(string filename, T objectToSerialize)
    {
        if(!typeof(objectToSerialize).IsSerializable)
        {
                  throw new Exception("objectToSerialize is not serializable");
        }
    }
