        public async Task<List<MyClass>> GetMyClassAsync(
        CancellationToken cancelToken = default(CancellationToken))
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = Util.getServiceUri("myservice");
                var response = await httpClient.GetAsync(uri, cancelToken);
                return (await response.Content.ReadAsAsync<List<MyClass>>());
            }
        }
