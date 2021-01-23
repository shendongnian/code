    public static void serializetoxml(object myobj) {
        XmlSerializer myserializer = new XmlSerializer(myobj.GetType());
        TextWriter mywriter = new StreamWriter("C:\\my.xml");
        myserializer.Serialize(mywriter, myobj);
        mywriter.Close();
    }
