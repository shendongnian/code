    public static List<T> CloneList<T>(List<T> oldList)  
    {  
    BinaryFormatter formatter = new BinaryFormatter();  
    MemoryStream stream = new MemoryStream();  
    formatter.Serialize(stream, oldList);  
    stream.Position = 0;  
    return (List<T>)formatter.Deserialize(stream);      
    } 
