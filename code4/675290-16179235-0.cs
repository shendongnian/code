    [XmlRoot("root")]
    public class container {
      [XmlArray("listContainer")]
      public List<listItem> listItem;
    }
    
    public class listItem {
        public XmlNode value;
    }
    class App {
      static void Main() {
        StreamReader fs = new StreamReader(@"sample.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(container));
        var result = serializer.Deserialize(fs) as container;  
        foreach (var res in result.listItem)
          Console.WriteLine(res.value.OuterXml);
      }
    }
