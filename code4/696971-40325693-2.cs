        [HttpPost]
        public async Task<HttpResponseMessage> FBLogin(Newtonsoft.Json.Linq.JObject jObject)
        {
            dynamic data = (dynamic)jObject;
            string accessToken = data.accessToken;
            ...
         }
    
