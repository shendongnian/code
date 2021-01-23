public static async Task<string> KeepAliveRequest(string url)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage()
    {
        RequestUri = new Uri("http://www.bing.com"),
        Method = HttpMethod.Get,
    };
    request.Headers.Add("Connection", new string[] { "Keep-Alive" });
    var responseMessage = await client.SendAsync(request);
    return await responseMessage.Content.ReadAsStringAsync();
}
