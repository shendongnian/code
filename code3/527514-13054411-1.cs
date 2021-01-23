    public pingResponse Send()
    {
      var pingRequest = new pingRequest
      {
        myelement = "test"
      };
    
      // Serialize pingRequest class to xml
      var serializer = new Serializer();
      string requestXml = serializer.SerializeObject(pingRequest, typeof(pingRequest));
    
      // Post xml
      var client = new WebClient(); 
      var uri = new Uri("http://www.site.com/"); 
      string responseXML = client.UploadString(uri, requestXML); 
    
      return (pingResponse)serializer.DeserializeObject(xml, typeof(Response));
    }
    
    
    public class Serializer
    {
      public string SerializeObject(object obj, Type type)
      {
        var setting = new XmlWriterSettings() {OmitXmlDeclaration = true, Indent = true};
        var xml = new StringBuilder();
        using (var writer = XmlWriter.Create(xml, setting))
        {
          var nsSerializer = new XmlSerializerNamespaces();
          nsSerializer.Add(string.Empty, string.Empty);
    
          var xmlSerializer = new XmlSerializer(type);
          xmlSerializer.Serialize(writer, obj, nsSerializer);
        }   
        return xml.ToString();
      }
    
      public object DeserializeObject(string xml, Type type)
      {
        var xs = new XmlSerializer(type);
        var stringReader = new StringReader(xml);
        var obj = xs.Deserialize(stringReader);
        stringReader.Close();
        return obj;
      }
    }
