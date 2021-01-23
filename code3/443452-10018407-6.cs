     public class MyEntity: IXmlDeserializationCallback
        {
             public string SomeData { get; set; }
             
             private void FixReferences()
             {
                  // call after deserialization
                  // ...
             }
    
             public void OnXmlDeserialization(object sender)
             {
                 FixReferences();
             } 
        }
    
        foreach (var xmlData in xmlArray)
        {
            var xmlSer = new CustomXmlSerializer(typeof(MyEntity));
            using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlData)))
            {
               var entity = (MyEntity)xmlSer.Deserialize(memStream);
               // entity.FixReferences(); - will be called automatically
    
               // do something else with the entity
               // ...  
            }
        }
