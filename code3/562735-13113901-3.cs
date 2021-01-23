    JsonConvert.SerializeObject(family, Formatting.Indented, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
        Context = new StreamingContext(StreamingContextStates.All, new JsonLinkedContext()),
    });
    JsonConvert.DeserializeObject<Family>(File.ReadAllText(@"..\..\Data\Family.json"), new JsonSerializerSettings {
        Context = new StreamingContext(StreamingContextStates.All, new JsonLinkedContext()),
    });
