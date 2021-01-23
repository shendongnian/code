    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Text;
    
    public class Test
    {
      
    /*
      // 
      // does not work - but see http://msdn.microsoft.com/en-us/magazine/cc164135.aspx
      // 
      public class Map : IXmlSerializable
      {
        const string NS = "http://xml.apache.org/xml-soap";
        public IDictionary dictionary;
        public Map()
        {
          dictionary = new Hashtable();
        }
      
        public Map(IDictionary dictionary)
        {
          this.dictionary = dictionary;
        }
      
        public void WriteXml(XmlWriter w)
        {
          w.WriteStartElement("Map", NS);
          foreach (object key in dictionary.Keys)
          {
            object value = dictionary[key];
            w.WriteStartElement("item", NS);
            w.WriteElementString("key", NS, key.ToString());
            w.WriteElementString("value", NS, value.ToString());
            w.WriteEndElement();
          }
          w.WriteEndElement();
        }
      
        public void ReadXml(XmlReader r)
        {
          r.Read(); // move past container
          r.ReadStartElement("dictionary");
          while (r.NodeType != XmlNodeType.EndElement)
          {
            r.ReadStartElement("item", NS);
            string key = r.ReadElementString("key", NS);
            string value = r.ReadElementString("value", NS);
            r.ReadEndElement();
            r.MoveToContent();
            dictionary.Add(key, value);
          }
        }
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }
      }
    */
    
      /*
       *  as per http://stackoverflow.com/a/1072815/2348103
       */
      public class Item
      {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string key;
        
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string value;
      }
    
      [SoapType(TypeName = "Map", Namespace = "http://xml.apache.org/xml-soap")]
      public class Map : List<Item>
      {
      }
    
      public static void Main()
      {
        Map map = new Map();
        map.Add( new Item { key="foo", value="bar" } );
        map.Add( new Item { key="quux", value="barf" } );
    
        XmlTypeMapping mapping = 
             (new SoapReflectionImporter()).ImportTypeMapping( map.GetType() );
        XmlSerializer serializer = new XmlSerializer( mapping );
        XmlTextWriter writer = new XmlTextWriter( System.Console.Out );
        writer.Formatting = Formatting.Indented;
        writer.WriteStartElement( "root" );
        serializer.Serialize( writer, map );
        writer.WriteEndElement();
        writer.Close();
      }
    }
