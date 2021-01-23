    class Program {
        static void Main(string[] args) {
            ServicePointManager.DefaultConnectionLimit = 500;
            CrawlAsync().ContinueWith(task => Console.WriteLine("***DONE!"));
            Console.ReadLine();
        }
        private static async Task CrawlAsync() {
            int numberOfCores = Environment.ProcessorCount;
            List<string> requestUris = File.ReadAllLines(@"C:\Users\Tugberk\Downloads\links.txt").ToList();
            ConcurrentDictionary<int, Tuple<Task, HttpRequestMessage>> tasks = new ConcurrentDictionary<int, Tuple<Task, HttpRequestMessage>>();
            List<HttpRequestMessage> requestsToDispose = new List<HttpRequestMessage>();
            var httpClient = new HttpClient();
            for (int i = 0; i < numberOfCores; i++) {
                string requestUri = requestUris.First();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                Task task = MakeCall(httpClient, requestMessage);
                tasks.AddOrUpdate(task.Id, Tuple.Create(task, requestMessage), (index, t) => t);
                requestUris.RemoveAt(i);
            }
            while (tasks.Values.Count > 0) {
                Task task = await Task.WhenAny(tasks.Values.Select(x => x.Item1));
                Tuple<Task, HttpRequestMessage> removedTask;
                tasks.TryRemove(task.Id, out removedTask);
                removedTask.Item1.Dispose();
                removedTask.Item2.Dispose();
                if (requestUris.Count > 0) {
                    var requestUri = requestUris.First();
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                    Task newTask = MakeCall(httpClient, requestMessage);
                    tasks.AddOrUpdate(newTask.Id, Tuple.Create(newTask, requestMessage), (index, t) => t);
                    requestUris.RemoveAt(0);
                }
                GC.Collect(0);
                GC.Collect(1);
                GC.Collect(2);
            }
            httpClient.Dispose();
        }
        private static async Task MakeCall(HttpClient httpClient, HttpRequestMessage requestMessage) {
            Console.WriteLine("**Starting new request for {0}!", requestMessage.RequestUri);
            var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            Console.WriteLine("**Request is completed for {0}! Status Code: {1}", requestMessage.RequestUri, response.StatusCode);
            using (response) {
                if (response.IsSuccessStatusCode){
                    using (response.Content) {
                        Console.WriteLine("**Getting the HTML for {0}!", requestMessage.RequestUri);
                        string html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        Console.WriteLine("**Got the HTML for {0}! Legth: {1}", requestMessage.RequestUri, html.Length);
                    }
                }
                else if (response.Content != null) {
                    response.Content.Dispose();
                }
            }
        }
    }
