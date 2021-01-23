    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.Serialization.Formatters.Binary;
    
    public static void WriteFile<T>(T obj, string path) 
    { 
        using (FileStream fs = File.OpenWrite(path))
        using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            bf.Serialize(gzip , obj); 
        }
    } 
    
    public static T LoadFile<T>(string path) 
    {  
        using (FileStream fs = File.OpenRead(path))
        using (GZipStream gzip = new GZipStream(fs, CompressionMode.Decompress))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            return (T)bf.Deserialize(gzip); 
        }
    }
