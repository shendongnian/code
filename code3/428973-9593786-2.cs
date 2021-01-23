    public class ThreadedHttpGetter
    {
        public IEnumerable<Task<HttpResponseMessage>> GetResponses(IEnumerable<string> uris)
        {
            foreach (string uri in uris)
            {
                using (var httpClient = new HttpClient())
                {
                    yield return httpClient.GetAsync(uri);
                }
            }
        }
    }
