    public abstract class XmlBaseClass  
    {
      public virtual string Serialize()
      {
        this.SerializeValidation();
        XmlSerializerNamespaces XmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        XmlWriterSettings XmlSettings = new XmlWriterSettings
        {
          Indent = true,
          OmitXmlDeclaration = true
        };
        StringWriter StringWriter = new StringWriter();
        XmlSerializer Serializer = new XmlSerializer(this.GetType());
        XmlWriter XmlWriter = XmlWriter.Create(StringWriter, XmlSettings);
        Serializer.Serialize(XmlWriter, this, XmlNamespaces);
        StringWriter.Flush();
        StringWriter.Close();
        return StringWriter.ToString();
      }
      protected virtual void SerializeValidation() {}
    }
    [XmlRoot(ElementName = "MyRoot", Namespace = "MyNamespace")]
    public class XmlChildClass : XmlBaseClass
    {
      protected override void SerializeValidation()
      {
        //Add custom validation logic here or anything else you need to do
      }
    }
