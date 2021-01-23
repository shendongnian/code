    public sealed class SubWebApi : BaseWebApi
    {
        public SubWebApi(HttpClient httpClient) : base(httpClient) {}
        public async Task<StuffResponse> GetStuffAsync(int cvr)
        {
            var method = "get/stuff";
            var request = new StuffRequest 
            {
                query = "GiveMeStuff"
            }
            return await PostAsync<StuffResponse>(method, request, GetHeaders(), HttpMethod.Post);
        }
        private Dictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>();
            var basicAuth = GetBasicAuth();
            headers.Add("Authorization", basicAuth);
            return headers;
        }
        private string GetBasicAuth()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{SystemSettings.Username}:{SystemSettings.Password}");
            var authString = Convert.ToBase64String(byteArray);
            return $"Basic {authString}";
        }
    }
