    /// <summary>
    /// Class containing the Configuration Storage
    /// </summary>
    [XmlRoot("Configuration")]
    public class ConfigurationStorage {
      /// <summary>
      /// Gets or sets the list of executers.
      /// </summary>
      [XmlArray("Executers")]
      [XmlArrayItem("Executer")]
      public Collection<string> Executers { get; private set; }
      /// <summary>
      /// Gets or sets the list of IPG prefixes.
      /// </summary>
      [XmlArray("IpgPrefixes")]
      [XmlArrayItem("IpgPrefix")]
      public Collection<string> IpgPrefixes { get; private set; }
      public ConfigurationStorage() {
        Executers = new Collection<string>();
        IpgPrefixes = new Collection<string>();
      }
    }
