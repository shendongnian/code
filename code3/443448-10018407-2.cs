    public class MyEntity
    {
         public string SomeData { get; set; }
         
         public void FixReferences()
         {
              // call after deserialization
              // ...
         }
    }
    foreach (var xmlData in xmlArray)
    {
        var xmlSer = new XmlSerializer(typeof(MyEntity));
        using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlData)))
        {
           var entity = (MyEntity)settingsSerializer.Deserialize(memStream);
           entity.FixReferences();
           // do something else with the entity
           // ...  
        }
    }
