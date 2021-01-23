    [XmlRoot("object")]
    public class Outer
    {
        [XmlElement("stuff")]
        public Inner Inner { get; set; }
    }
    public class Inner
    {
        [XmlElement("body")]
        public XmlElement Body { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.LoadXml(
               "<random>This could be any rondom piece of unknown xml</random>");
            var obj = new Outer {Inner = new Inner { Body = doc.DocumentElement }};
    
            new XmlSerializer(obj.GetType()).Serialize(Console.Out, obj);
        }
    }
