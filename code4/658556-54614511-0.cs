    var httpClientWrapper = new Neo4jClient.HttpClientWrapper(
            username,
            password,
            new System.Net.Http.HttpClient() {
                 Timeout = System.Threading.Timeout.InfiniteTimeSpan
            });
                    
    var graphClient = new Neo4jClient.GraphClient(new Uri(url), httpClientWrapper);
