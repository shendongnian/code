    public static void serializetoxml<T>(T myobj)
    {
        XmlSerializer myserializer = new XmlSerializer(typeof(T));
        TextWriter mywriter = new StreamWriter("C:\\my.xml");
        myserializer.Serialize(mywriter, myobj);
        mywriter.Close();
    }
