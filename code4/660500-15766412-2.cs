    public static T ExecuteAPIGetRequest<T>(string url, 
                                            Dictionary<string, string> parameters)
                                                                       where T : new()
    {
        HttpClient client = new HttpClient();
        //basic authentication
        string baseURL =  "myurl"; 
        HttpResponseMessage response = client.GetAsync(baseURL).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadAsAsync<T>().Result;  
        }
        else
        {
            return new T(); //returns an instance, not null
        }
    }
