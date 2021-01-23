    public static IRestResponse Create<T>(object objectToUpdate, string apiEndPoint) where T : new()
    {
        var client = new RestClient(CreateBaseUrl(null))
        {
            Authenticator = new HttpBasicAuthenticator("user", "Password1")
        };
        var request = new RestRequest(apiEndPoint, Method.POST);
        request.AddJsonBody(objectToUpdate); // HERE
        var response = client.Execute<T>(request);
        return response;
    }
