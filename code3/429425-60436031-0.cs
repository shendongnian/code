            WebProxy proxy = new WebProxy
            {
                Address = new Uri(""),
                Credentials = new NetworkCredential("", "")
            };
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };
            HttpClient client = new HttpClient(httpClientHandler);
            HttpResponseMessage response = await client.PostAsync("...");
