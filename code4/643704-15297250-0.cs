    Collection<object> list = new Collection<object>();
    //Now I will write this list to a file. fileName is what you want and be sure that folder Files is exist on server or at the root folder of your project
    WriteFile(list, Server.MapPath("~/Files/" + fileName));
    //The method to write object to file is here
    public static void WriteFile<T>(T obj, string path)
    {
        FileStream serializeStream = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(serializeStream, obj);
        serializeStream.Flush();
        serializeStream.Close();
    }
