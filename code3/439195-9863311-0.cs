    HttpClient httpClient = new HttpClient();
    HttpContent content = new StringContent(@"{ ""Username"": """ + "etc." + @"""}");
    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    HttpResponseMessage response = 
        await httpClient.PostAsync("http://myapi.com/authentication", content);
    string statusCode = response.StatusCode.ToString();
