    using System.Text; // needed to specify output file encoding
    using System.Xml;
    using System.Xml.Serialization; // XmlSerializer lives here
    // instance of your generated class
    YourClass c = new YourClass();
    // wrap XmlTextWriter into a using block because it supports IDisposable
    using (XmlTextWriter tw = new XmlTextWriter(@"C:\MyClass.xml", Encoding.UTF8))
    {
        // create an XmlSerializer for your class type
        XmlSerializer xs = new XmlSerializer(typeof(YourClass));
        xs.Serialize(tw, c);
    }
