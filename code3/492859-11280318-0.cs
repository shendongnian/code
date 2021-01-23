    using System.Xml;
    using System.Xml.Serialization;
    YourClass c = new YourClass();
    XmlSerializer xs = new XmlSerializer(typeof(YourClass));
    XmlTextWriter tw = new XmlTextWriter(@"C:\MyClass.xml", System.Text.Encoding.UTF8);
    xs.Serialize(tw, c);
