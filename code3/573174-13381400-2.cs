    [Serializable]
    public class Result : IXmlSerializable
    {
        public int? SomeInt { get; set; }
        #region IXmlSerializable members
        public void WriteXml(XmlWriter writer)
        {
            if (SomeInt != null) { writer.WriteValue(writer); }
        }
        public void ReadXml(XmlReader reader)
        {
            int result;
            if (int.TryParse(reader.GetAttribute("SomeInt"), out result))
                SomeInt = result;
        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
        #endregion
    }
