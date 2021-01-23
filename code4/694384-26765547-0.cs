    public class ProxyController : ApiController
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly Uri BaseUri = new Uri("http://webendpoint.com");
    
        public async Task<HttpResponseMessage> Post()
        {
            var newUri = new Uri(BaseUri, Request.RequestUri.PathAndQuery);
            var request = new HttpRequestMessage(HttpMethod.Post, newUri)
            {
                Content = Request.Content
            };
    
            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    
            return new HttpResponseMessage(response.StatusCode)
            {
                Content = new PushStreamContent(async (stream, content, ctx) =>
                {
                    var tempStream = await response.Content.ReadAsStreamAsync();
                    await tempStream.CopyToAsync(stream);
                    stream.Flush();
                    stream.Close();
                })
            };
        }
    }
