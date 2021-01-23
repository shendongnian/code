    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    dict.Add("test", new List<string>() { "t", "b" });
    StringBuilder xmlString = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(xmlString))
    {
        DataContractSerializer serializer = new DataContractSerializer(dict.GetType());
        serializer.WriteObject(writer, dict);
    }
