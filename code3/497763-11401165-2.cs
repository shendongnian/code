    var client = new RestClient(ServiceUrl);
    
    var request = new RestRequest("/resource/", Method.POST);
    
    // Json to post.
    string jsonToSend = JsonHelper.ToJson(json);
    
    request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
    request.RequestFormat = DataFormat.Json;
    
    try
    {
        client.ExecuteAsync(request, response =>
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // OK
            }
            else
            {
                // NOK
            }
        });
    }
    catch (Exception error)
    {
    	// Log
    }
