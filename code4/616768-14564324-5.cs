    public List<T> DeserializeList<T>(string filePath)
    {
        var itemList = new List<T>();
    
        if (File.Exists(filePath))
        {
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Root"));
            TextReader reader = new StreamReader(filePath);
            itemList = (List<T>)serializer.Deserialize(reader);
            reader.Close();
        }
    
        return itemList;
    }
