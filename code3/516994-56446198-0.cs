    [XmlInclude(typeof(Derived))]
    public class Base {}
    
    public class Derived : Base {}
    
    public void Serialize()
    {
        TextWriter writer = new StreamWriter(SchedulePath);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Derived>));
        xmlSerializer.Serialize(writer, data);
        writer.Close();
    }
