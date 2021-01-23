    using (var client = new HttpClient())
    {
        client.BaseAddress  = baseAddress;
        client.Timeout      = timeout;
    
        using (var response = client.PostAsJsonAsync<YourObjectType>("controller_name", yourObject).Result)
        {
            if (!response.IsSuccessStatusCode)
            {
                // throw an appropriate exception
            }
    
            result  = response.Content.ReadAsAsync<YourObjectType>().Result;
        }
    }
