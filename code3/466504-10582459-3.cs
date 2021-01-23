    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
      [XmlRoot("ExtendedAttributes")]
      public class SerialisableDictionary : Dictionary<string, string>, IXmlSerializable
      {
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
          return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
          reader.Read();
          while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
          {
            string key = reader.Name;
            this.Add(key, reader.ReadElementContentAsString());
            reader.MoveToElement();
          }
          reader.ReadEndElement();
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
          // TODO
        }
        #endregion
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          SerialisableDictionary sd = new SerialisableDictionary();
          XmlSerializer x = new XmlSerializer(sd.GetType());
          using (StreamReader sr = new StreamReader(@"XMLFile1.xml"))
          {
            sd = (SerialisableDictionary)x.Deserialize(sr);
          }
          foreach(var kvp in sd)
          {
            Console.WriteLine(kvp.Key + " = " + kvp.Value);
          }
          Console.WriteLine("Done.");
          Console.ReadKey();
        }
      }
