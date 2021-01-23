    public IWebRequestFactory
    {
         HttpWebRequest Create(string uri);
    }
    
    
    public class Consumer
    {
         public IHttpWebRequestFactory WebRequestFactory { get; private set; }
    
         public Consumer(IHttpWebRequestFactory webRequestFactory)
         {
            WebRequestFactory = webRequestFactory;
         }
    
         public Foo GoGetSomeJsonForMePleaseKThxBai()
        {
            // prep stuff ...
        
            // Now get json please.
            HttpWebRequest httpWebRequest = WebRequestFactory.Create("Http://some.fancypants.site/api/hiThere);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
        
            string responseText;
        
            using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    json = streamReader.ReadToEnd().ToLowerInvariant();
                }
            }
        
            // Check the value of the json... etc..
        }
    
    }
