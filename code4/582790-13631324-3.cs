        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            DataContractJsonSerializerSettings settings = 
                    new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            DataContractJsonSerializer serializer = 
                    new DataContractJsonSerializer(typeof(CustomObject), settings);
            CustomObject results = (CustomObject)serializer.ReadObject(ms);
            Dictionary<string, object> parent = results.Parent;
        }
