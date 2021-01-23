    public static ICollection<T> DeserializeList<T>(FileStream fs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        List<T> list = new List<T>();
        while(fs.Position!=fs.Length)
        {
             //deserialize each object in the file
             var deserialized = (T)bf.Deserialize(fs); 
             //add individual object to a list
             list.Add(deserialized);
        }
        //return the list of objects
        return list;
    }
