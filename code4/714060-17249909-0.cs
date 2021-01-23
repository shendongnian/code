    public class ServerConnections
    {
        public ServerConnectionEntry[] Entries { get; set; }
    }
    public class ServerConnectionEntry
    {
        public string Name { get; set; }
    }
    [TestClass]
    public class DeserializationTest
    {
        public const string MyXml = @"<?xml version=""1.0""?>
    <ServerConnections 
       xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
       xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <Entries>
        <ServerConnectionEntry>
          <Name>Local</Name>
          <Host>127.0.0.1</Host>
          <Port>15556</Port>
          <Username>TestUser</Username>
          <AuthHash>
            <base64Binary>u7a0NN4uOvCrb5t5UWVVEl14Ygo=</base64Binary>
          </AuthHash>
        </ServerConnectionEntry>
        <ServerConnectionEntry>
          <Name>Local2</Name>
          <Host>127.0.0.1</Host>
          <Port>15556</Port>
          <Username>TestUser</Username>
          <AuthHash>
            <base64Binary>u7a0NN4uOvCrb5t5UWVVEl14Ygo=</base64Binary>
          </AuthHash>
        </ServerConnectionEntry>
      </Entries>
    </ServerConnections>
    ";
        [TestMethod]
        public void Deserialization_Has_Two_Elements()
        {
            TextReader reader = new StringReader(MyXml);
            var mySerializer = new XmlSerializer(typeof(ServerConnections));
    
            var list = ((ServerConnections)mySerializer.Deserialize(reader)).Entries;
    
            Assert.IsTrue(list.Count() == 2);
    
            Assert.IsTrue(list.First().Name == "Local");
            Assert.IsTrue(list.Last().Name == "Local2");
        }
    }
