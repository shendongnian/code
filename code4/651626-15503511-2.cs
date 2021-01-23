    public class MeterValuesList : IList<MeterValues>, IXmlSerializable
    {
        MeterValues[] _MeterList { get; set; }
        string CommSettings = "Com5:19200,8,n,1";
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("CommSettings ", CommSettings );
            foreach (var mv in _MeterList)
            {
                // kind of a bad example, but hopefully you get the idea
                if (mv== null) 
                    return;
                writer.WriteStartElement("MeterValues");
                mv.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
