    public static class ClientHelper
    {
        public static HttpClient GetClient(string username,string password)
        {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                
                var client = new HttpClient(){
                    DefaultRequestHeaders = { Authorization = authValue}
                    //Set some other client defaults like timeout / BaseAddress
                };
                return client;
        }
    }
    
