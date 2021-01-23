    using (JsonWriter file = new Newtonsoft.Json.Bson.BsonWriter(new StreamWriter("Test.txt")))
    {
       file.WriteStartObject();
       file.WritePropertyName("TEST");
       file.WriteValue("test");
       file.WriteEndObject();
    }
