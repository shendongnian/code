    public class PluginMemento {
         [XmlAttribute] public string Type { get; set; }
         [XmlElement] public string Name { get; set; }
         [XmlElement] public string Message { get; set; }
         [XmlElement] public string Key { get; set; }
         ..... //all the other properties
    }
    [XmlRootAttribute("Client")]
    public class Client {
       
       [XmlElementAttribute("Plugin")]
       public PluginMemento[] plugins;
    }
