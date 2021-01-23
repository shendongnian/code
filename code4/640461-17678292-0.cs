        public HttpStatusCode PostStaffPositions(Foo foo)
        {
            string uri = myapiuri;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.PostAsJsonAsync(uri, foo).Result;
                return response.StatusCode;
            }
        }
