    using System.Net.Http.Formatting;
    // ...
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.PostAsyc("{send the request to api}");
    var content = await response.Content.ReadAsMultipartAsync();
    
    var stringContent = await content.Contents[0].ReadAsStringAsync();
    var streamContent = await content.Contents[1].ReadAsStreamAsync(); 
