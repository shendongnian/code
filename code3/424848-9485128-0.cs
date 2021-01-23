    public async Task<string> MakeWebRequest()
    {
           HttpClient http = new System.Net.Http.HttpClient();
    
           HttpResponseMessage response = await http.GetAsync("http://www.example.com");
    
           return response.Content.ReadAsString();
    }
