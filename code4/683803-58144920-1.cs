    var requestUri = new Uri("http://UrlOfTheApi");
    using (var streamToPost = new MemoryStream("C:\temp.txt"))
    using (var fileStreamContent = new StreamContent(streamToPost))
    using (var httpClientHandler = new HttpClientHandler() { UseDefaultCredentials = true })
    using (var httpClient = new HttpClient(httpClientHandler, true))
    using(var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri))
    using (var formDataContent = new MultipartFormDataContent())
    {
           formDataContent.Add(fileStreamContent, "myFile", "temp.txt");
           requestMessage.Content = formDataContent;
           var response = httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
           if (response.IsSuccessStatusCode)
           {
                 //file upload was successfull
           }
           else
           {
                 var erroResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                 throw new Exception("Error on the server : " + erroResult);
            }
    }
