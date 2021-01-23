    [Serializable]
    public class Threshold : ICloneable, IXmlSerializable
    {
    
    public int Type {get;set;}
    public object Value {get;set;}
    public string Name {get;set;}
    public void ReadXml(System.Xml.XmlReader reader)
    {
    
    
    XElement thresholdXML = XElement.Load(reader);
    
    if (!thresholdXML.HasElements || thresholdXML.IsEmpty)
    return;
    
    Type = (ThresholdType)int.Parse(thresholdXML.Element("Type").Value);
    Value = Type.Equals(ThresholdType.Complex) ? thresholdXML.Element("Value").Value : (object)Decimal.Parse(thresholdXML.Element("Value").Value);
    Name = thresholdXML.Element("Name").Value;
    
    
    }
    
    
    public System.Xml.Schema.XmlSchema GetSchema()
    {
    return null;
    }
    
    public void WriteXml(System.Xml.XmlWriter writer)
    {
    XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
    xmlnsEmpty.Add("", "");
    
    
    writer.WriteElementString("Type", ((int)Type).ToString("D"));
    writer.WriteElementString("Value", Value.ToString());
    writer.WriteElementString("Name", Name);
    }
    }
