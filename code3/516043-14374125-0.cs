    class Program
    {
        private const string baseAddress = "http://localhost:8080/";
        static void Main(string[] args)
        {   
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration(baseAddress);
            configuration.Routes.MapHttpRoute("default", "api/{controller}");
            HttpSelfHostServer server = new HttpSelfHostServer(configuration);
            try
            {
                server.OpenAsync().Wait();
                RunClient();
            }
            finally
            {
                server.CloseAsync().Wait();
            }
        }
        static void RunClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            HttpResponseMessage response = client.GetAsync("api/Test?id=1").Result;
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
    public class MyObject
    {
        public string name = "foo";
        public int age = 33;
        public MyObject(string n)
        {
            name = n;
        }
    }
    public class TestController : ApiController
    {
        // GET api/values/5
        public MyObject Get(int id)
        {
            return new MyObject("Getted");
        }
    }
