    //Here I call the method with parameter of Collection of objects
    Collection<object> list = new Collection<object>();
    list.Add("value1");
    list.Add("value2");
    list.Add("value3");
    SaveListToFile(list);
    public void SaveListToFile(Collection<object> list)
    {
        var serializer = new XmlSerializer(typeof(Collection<object>));
        using (var writer = new StreamWriter(Server.MapPath("~/Files/test.xml")))
            serializer.Serialize(writer, list);
    }
