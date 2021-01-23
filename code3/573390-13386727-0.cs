    HttpResponseMessage response;
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://url_to_service");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var responseTask = client.PostAsJsonAsync("api/resource/somethingelse", someObjectToPost).Result;
    responseTask.Wait();
    response = responseTask.Result;
    if (response.IsSuccessStatusCode)
    {
        var contentTask = response.Content.ReadAsAsync<SomeResponseType>();
        contentTask.Wait();
        SomeResponseType responseContent = contentTask.Result;
    }
    else
    {
        //Handle error.
    }
