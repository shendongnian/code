     // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            var result = await GetExternalResponse();
            
            return new string[] { result, "value2" };
        }
        private async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
