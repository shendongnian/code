    public static void Serialize<T>(string path, string filename, T entity)
    {
        string fullpath = path + "\\" + filename;
        using (TextWriter writer = new StreamWriter(fullpath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, entity);
        }
    }
