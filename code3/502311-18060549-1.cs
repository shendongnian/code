    public T Execute<T>(RestRequest request) where T : class, new()
    {
        RestClient client = new RestClient(baseUrl);
        client.AddHandler("text/plain", new JsonDeserializer());
        try
        {
            var response = client.Execute<T>(request);
            return response.Data;
        }
        catch (Exception ex)
        {
            // This is ugly, but if you don't want to bury any errors except when trying to deserialize an empty array to a dictionary...
            if (ex is InvalidCastException && typeof(T) == typeof(Dictionary<string, MyObject>))
            {
                // Log the exception?
                return new T();
            }
            throw;
        }
    }
