    public static ICollection<T> DeserializeList<T>(FileStream fs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        List<T> list = new List<T>();
        while(fs.Position!=fs.Length)
        {
             //deserialize each object
             var deserialized = (T)bf.Deserialize(fs)
             //add individual object to a list
             list.add(deserialized);
        }
        //return the list of objects
        return list;
    }
