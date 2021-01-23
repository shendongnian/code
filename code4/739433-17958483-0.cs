    [Serializable()]
    public class Command
    {
      [System.Xml.Serialization.XmlElement("Name")]
      public string Name { get; set; }
      [System.Xml.Serialization.XmlElement("CMD")]
      public string Cmd { get; set; }
      [System.Xml.Serialization.XmlElement("Feature")]
      public string Feature { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("ATAPassthrough")]
    public class CommandCollection
    {
      [XmlArrayItem("Command", typeof(Command))]
      public Command[] Command { get; set; }
    }
