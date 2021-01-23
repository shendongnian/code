     public static IRestResponse Create<T>(object objectToUpdate, string apiEndPoint) where T : new()
        {
            var client = new RestClient(CreateBaseUrl(null))
            {
                Authenticator = new HttpBasicAuthenticator("user", "Password1")
            };
            var json = JsonConvert.SerializeObject(objectToUpdate);
            var request = new RestRequest(apiEndPoint, Method.POST);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            var response = client.Execute<T>(request);
            return response;
        }
