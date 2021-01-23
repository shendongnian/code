    public static T getDeepCopy<T>( T objectToCopy )
    {
        T temp;
        using ( MemoryStream ms = new MemoryStream() )
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize( ms, objectToCopy );
            ms.Position = 0;
            temp = (T)formatter.Deserialize( ms );
        }
        return temp;
    }
