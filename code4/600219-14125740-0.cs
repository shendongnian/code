    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace E_Cv.Functions
    {
        public class NewCVXml :IXmlSerializable
        {
    
            public List<string> FieldFirst { get; set; }
            public List<string> FieldSecond { get; set; }
            public List<string> FieldThird { get; set; }
    
            public void WriteXml(XmlWriter writer)
            {
    
       
                for (int i = 0; i < FieldFirst.Count; i++)
                {
    
                    writer.WriteStartElement("Satir");
    
                    writer.WriteAttributeString("AlanIsmi",FieldFirst[i]);
                    //writer.WriteString(FieldFirst[i]);    
                    writer.WriteAttributeString("AlanTuru", FieldThird[i]);
                    writer.WriteString(FieldSecond[i]); 
                    writer.WriteEndElement();
                }
          
    
            }
    
            public void ReadXml(XmlReader reader)
            {
                // Custom Deserialization Here
            }
    
            public XmlSchema GetSchema()
            {
                return (null);
            }
        }
    }
