    public abstract class BaseWebApi
    {
        //Inject HttpClient from Ninject
        private readonly HttpClient _httpClient;
        public BaseWebApi(HttpClient httpclient)
        {
            _httpClient = httpClient;
        }
        public async Task<TOut> PostAsync<TOut>(string method, object param, Dictionary<string, string> headers, HttpMethod httpMethod)
        {
        //Set url
            HttpResponseMessage response;
            using (var request = new HttpRequestMessage(httpMethod, url))
            {
                AddBody(param, request);
                AddHeaders(request, headers);
                response = await _httpClient.SendAsync(request, cancellationToken);
            }
        //Exception handling
        }
        private void AddHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers == null) return;
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
        private static void AddBody(object param, HttpRequestMessage request)
        {
            if (param != null)
            {
                var content = JsonConvert.SerializeObject(param);
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
