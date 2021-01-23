    using System.Runtime.Serialization.Formatters.Binary;
    
    BinaryFormatter binary = BinaryFormatter();
    using (FileStream fs = File.Create(file))
    {
        bs.Serialize(fs, objectArray);
    }
