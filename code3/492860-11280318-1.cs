    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    YourClass c = new YourClass();
    XmlSerializer xs = new XmlSerializer(typeof(YourClass));
    using (XmlTextWriter tw = new XmlTextWriter(@"C:\MyClass.xml", Encoding.UTF8))
    {
        xs.Serialize(tw, c);
    }
