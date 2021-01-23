        var client = new HttpClient();
        var request = new HttpRequestMessage() {
                                                   RequestUri = new Uri("http://www.someURI.com"),
                                                   Method = HttpMethod.Get,
                                               };
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        var task = client.SendAsync(request)
            .ContinueWith((taskwithmsg) =>
            {
                var response = taskwithmsg.Result;
                var jsonTask = response.Content.ReadAsAsync<JsonObject>();
                jsonTask.Wait();
                var jsonObject = jsonTask.Result;
            });
        task.Wait();
    }
