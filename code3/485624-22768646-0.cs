    while (jsonReader.Read())
    {
        if (jsonReader.TokenType == JsonToken.StartObject)
        {
            newTweetCallback(jsonSerializer.Deserialize<Tweet>(jsonReader));
            // Debug.Assert(jsonReader.TokenType == JsonToken.EndObject);
        }
    }
