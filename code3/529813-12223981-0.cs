     public static IRestResponse Update<T>(object objectToUpdate,string apiEndPoint)
    {
        var client = new RestClient(CreateBaseUrl(null))
        {
            Authenticator = new HttpBasicAuthenticator("user", "Password1")
        };
        var request = new RestRequest(apiEndPoint, Method.PUT);
        request.AddObject(objectToUpdate);
        var response = client.Execute<T>(request);
        //var response = client.ExecuteDynamic(request);
        return response;
    }
