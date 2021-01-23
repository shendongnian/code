    using System.Net;
    using System.Net.Http;
    var httpClient = new HttpClient();
    var message = new HttpRequestMessage(HttpMethod.Get, targetURL);
    //message.Headers.Add(....);
    //message.Headers.Add(....);
    
    var response = await httpClient.SendAsync(message);
    if (response.StatusCode == HttpStatusCode.OK)
    {
        //HTTP 200 OK
        var requestResultString = await response.Content.ReadAsStringAsync();
    }
