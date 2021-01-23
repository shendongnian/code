    public T Execute<T>(RestRequest request) where T : class, new()
    {
        RestClient client = new RestClient(baseUrl);
        client.AddHandler("text/plain", new JsonDeserializer());
        try
        {
            var response = client.Execute<T>(request);
            return response.Data;
        }
        catch (Exception)
        {
            // Log the exception?
            return new T();
        }
    }
