    public class OtherInfo: IXmlSerializable
    {
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            var content = reader.ReadElementContentAsString();
            if (String.IsNullOrWhiteSpace(content))
                return;
            var infos = content.Split(':');
            if (infos.Length < 2)
                return;
            this.Info1 = infos[0];
            this.Info2 = infos[1];
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(String.Format("{0}:{1}", this.Info1, this.Info2));
        }
    }
