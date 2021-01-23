    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            //basic authentication
            string baseURL = "myurl";
            var link = Link<Foo>.Create(baseURL);
            var response = client.SendAsync(link.CreateRequest()).Result;
            var myfoo = link.ProcessResponse(response);
        }
    }
   
    public class Link<T>
    {
        public Uri Target { get; set; }
        public static Link<T> Create(string url)
        {
            return new Link<T>() {Target = new Uri(url)};
        }
        
        public HttpRequestMessage CreateRequest()
        {
            return new HttpRequestMessage() {RequestUri = Target};
        }   
        public T ProcessResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                return new T(); //returns an instance, not null
            }
        }
    }
    public class Foo
    {
    }
