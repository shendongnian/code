    public static void Serialize(object t, string path)
    {
        using(Stream stream = File.Open(path, FileMode.Create))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, t);
        }
    }
    //Could explicitly return 2d array, 
    //or be casted from an object to be more dynamic
    public static object Deserialize(string path) 
    {
        using(Stream stream = File.Open(path, FileMode.Open))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            return bformatter.Deserialize(stream);
        }
    }
        
