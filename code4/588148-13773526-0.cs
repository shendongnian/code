     public class TextController : ApiController
        {
            public HttpResponseMessage Post(HttpRequestMessage request) {
                var someText = request.Content.ReadAsStringAsync().Result;
                return new HttpResponseMessage() {Content = new StringContent(someText)};
            }
    
        }
