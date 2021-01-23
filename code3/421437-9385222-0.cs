    public static void serializetoxml(object myobj)
    {
        XmlSerializer myserializer = new XmlSerializer(obj1.GetType());
        TextWriter mywriter = new StreamWriter("C:\\my.xml");
        myserializer.Serialize(mywriter, myobj);
        mywriter.Close();
    }
