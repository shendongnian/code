    namespace TestSerialization
    {
        using System;
        using System.IO;
        using System.Xml;
        using System.Xml.Serialization;
    
        public class TestSerialization
        {
            static void Main(string[] args)
            {
                string theXml =
    @"<ship name='Foo'>
     <base_type>Foo</base_type>
     <GFX>fooGFX</GFX>
    </ship>";
                Ship s = Ship.Create(theXml);
    
                // Write out the properties of the object.
                Console.Write(s.Name + "\t" + s.GFX);
            }
        }
    
        [XmlRoot("ship")]
        public class Ship
        {
            public Ship() { }
    
            public static Ship Create(string xmlText)
            {
                // Create an instance of the XmlSerializer specifying type.
                XmlSerializer serializer = new XmlSerializer(typeof(Ship));
    
                StringReader sr = new StringReader(xmlText);
    
                XmlReader xreader = new XmlTextReader(sr);
    
                // Declare an object variable of the type to be deserialized.
                Ship s;
    
                // Use the Deserialize method to restore the object's state.
                return (Ship)serializer.Deserialize(xreader);
            }
            
            [XmlAttribute("name")]
            public string Name;
    
            [XmlElement("base_type")]
            public string Base_type;
    
            public string GFX;
        }
    }
