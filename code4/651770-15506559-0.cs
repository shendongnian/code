    [XmlRoot("MyRoot")]
    public sealed class SomeInformation
    {
      public SomeInformation() { }
      [XmlElement("SomeNode1")]
      public String Prop1 { get { return "Some prop 1"; } set { } }
      [XmlElement("SomeNode2")]
      public String Prop2 { get { return "Some prop 2"; } set { } }
    }
