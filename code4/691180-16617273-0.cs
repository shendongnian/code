    public class MyClass
    {
       [XmlElement("Element")]
       int Element { get; set; }
 
    }
    class Program
    {
       static void Main(string[] args)
       {
          string xml = "<Element>String</Element>";
          XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
          serializer.Deserialize(new StringReader(xml));
       }
    }
