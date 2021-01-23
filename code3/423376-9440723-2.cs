    public static T Deserialize<T>(string path, string filename)
    {
        T result = default(T);
        string fullpath = path + "\\" + filename;
        using (TextReader reader = new StreamReader(fullpath))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            result = (T)deserializer.Deserialize(reader);
        }
        return result;
    }
