    public static void WriteFile<T>(T obj, string path) 
    { 
        using (FileStream fs = new FileStream(path); 
        using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            bf.Serialize(gzip , obj); 
        }
    } 
     
    public static T LoadFile<T>(path) 
    {  
        using (FileStream fs = new FileStream(path))
        using (GZipStream gzip = new GZipStream(fs, CompressionMode.Decompress);
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            return T = (T)bf.Deserialize(gzip); 
        }
    }
