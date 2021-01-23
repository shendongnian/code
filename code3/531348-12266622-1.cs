    public class Person : IXmlSerializable
    {
        [XmlElement("firstname")]
        public string FirstName { get; set; }
        [XmlElement("postcode")]
        public string Postcode { get; set; }
        #region IXmlSerializable Member
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader.Read())
            {
                FirstName = reader.ReadInnerXml();
            }
            reader.Read(); 
            Postcode = reader.ReadInnerXml();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("firstname ", FirstName);
            writer.WriteStartElement("address");
            writer.WriteElementString("postcode", Postcode);
            writer.WriteEndElement();
        }
        #endregion
        // for demo purposes only !
        public override string ToString()
        {
            return FirstName + ", " + Postcode;
        }
        // source to test the exported file and read it right after!
        Person p = new Person() { FirstName = "jon doe", Postcode = "N1 OX" };
        XmlSerializer xs = new XmlSerializer(typeof(Person));
        StreamWriter sw = new StreamWriter("export.xml");
        xs.Serialize(sw, p);
        sw.Close();
        StreamReader sr = new StreamReader("export.xml");
        Person p1 = xs.Deserialize(sr) as Person;
        Debug.WriteLine(p1.ToString());
