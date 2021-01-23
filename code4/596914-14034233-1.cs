    List<Word> Words = ........
    WriteXML("a.xml", Words);
    var newWords = ReadXML<List<Word>>("a.xml");
---
    public static void WriteXML(string fileName,object obj)
    {
        using (var f = File.Create(fileName))
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            ser.Serialize(f, obj);
        }
    }
    public static T ReadXML<T>(string fileName)
    {
        using (var f = File.Open(fileName,FileMode.Open,FileAccess.Read))
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(f);
        }
    }
