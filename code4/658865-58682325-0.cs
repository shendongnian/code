    public static void Save(string filename, object obj)
    {
        try
        {
            using Stream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            var b = new BinaryFormatter();
            b.Serialize(s, obj);
        }
        catch(SerializationException e)
        {
            var type= e.Message.Split("in Assembly")[0].Replace("Type", string.Empty).Replace("'", string.Empty).Trim();
            var assembly=e.Message.Split("in Assembly")[1].Split("'")[1];
            var atype= Type.GetType(type);
                    
            string path = FindObject(new Stack<object>(new object[] { obj }), atype, "[myself]");
    
            throw new SerializationException($"Could not serialize path {path} in {obj.GetType().Name} due to not being able to process {type} from {assembly}. see inner exception for details", e);
        }            
    }
