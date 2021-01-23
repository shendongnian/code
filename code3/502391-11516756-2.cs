    XmlSerializer ser = new XmlSerializer(typeof(SomeItem));
    ser.Serialize(stream, new SomeItem());
    public class SomeItem
    {
        public string Name;
        public int ID;
    }
