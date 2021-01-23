    static public void SerializeToXML(Actor actor)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Actor));
        TextWriter textWriter = new StreamWriter(@"c:\users\Desktop\actor.xml",true);
        serializer.Serialize(textWriter, actor);
        textWriter.Close();
    }
