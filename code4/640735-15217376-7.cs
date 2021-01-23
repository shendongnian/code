public static async Task<string> KeepAliveRequest()
{
    var handler = new HttpClientHandler();
    var client = new HttpClient(handler as HttpMessageHandler);
    HttpContent content = new StringContent(post data here if doing a post);
    content.Headers.Add("Keep-Alive", "true");
    //choose your type depending what you are sending to the server
    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
    HttpResponseMessage response = await client.PostAsync(url, content);
    Stream stream = await response.Content.ReadAsStreamAsync();
    return new StreamReader(stream).ReadToEnd();
}
