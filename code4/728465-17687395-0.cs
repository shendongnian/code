    class Network
    {
       static CookieContainer cookieJar = new CookieContainer();
       List<KeyValuePair<string, string>> postParameters = new List<KeyValuePair<string, string>>();
       // Add post parameter before calling NetworkRequestAsync for POST calls.
       public void addPostParameter(String key, String value)
       {
           postParameters.Add(new KeyValuePair<string, string>(key, value));
               
        }
        public async Task<byte[]> NetworkRequestAsync(String url, bool GET_REQUEST)
        {
            callSuccess = false;
            byte[] respBytes = null;
            try
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    // Use and reuse cookies in the cookiejar 
                    CookieContainer = cookieJar
                };
                handler.AllowAutoRedirect = false;
                handler.UseCookies = true;
                HttpClient client = new HttpClient(handler as HttpMessageHandler)
                {
                    BaseAddress = new Uri(@url)
                };
                HttpResponseMessage response = null;
                if (GET_REQUEST)
                {
                    response = await client.GetAsync(client.BaseAddress);
                }
                else
                {
                    HttpContent content = new FormUrlEncodedContent(postParameters);
                    //String postparam=await content.ReadAsStringAsync();
                    //Debug.WriteLine("Post Param1=" + postparam);
                    response = await client.PostAsync(client.BaseAddress, content);
                    callSuccess = true;
                }
                respBytes = await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception performing network call : " + e.ToString());
            } 
            
            return respBytes;
        }
}
