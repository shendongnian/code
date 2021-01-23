    using (var reader = new JsonTextReader(File.OpenText("path")))
    {
        while (reader.Read())
        {
            // Your logic here (anything you need is in [reader] object), for instance:
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Process array
                MyMethodToProcessArray(reader);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // Process object
                MyMethodToProcessObject(reader);
            }
        }
    }
