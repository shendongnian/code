csharp
async Task SendPostRequest()
{
    HttpClient client = new HttpClient();
    var requestContent = new StringContent(<content>);
    requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    var response = await client.PostAsync(<url>, requestContent);
    var responseString = await response.Content.ReadAsStringAsync();
}
...
   
SendPostRequest().Wait();
